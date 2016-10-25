using System;
using System.Xml;
using Interop.QBXMLRP2;
using System.Collections.Generic;
using QuickBooksIntegration.Base;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.IO;
using System.Diagnostics;
using RestSharp;

namespace QuickBooksIntegration
{
    class PushData
    {
        private XmlElement MakeSimpleElem(XmlDocument doc, string tagName, string tagVal)
        {
            XmlElement elem = doc.CreateElement(tagName);
            elem.InnerText = tagVal;
            return elem;
        }

        public void Export(out string responseStrEx, out string responseStrPL)
        {
            Config.InitConfig();

            bool sessionBegun = false;
            bool connectionOpen = false;
            RequestProcessor2 rp = null;

            //try
            //{

                rp = new RequestProcessor2();

            //Expense Type
            XmlDocument requestExXmlDoc = new XmlDocument();
            requestExXmlDoc.AppendChild(requestExXmlDoc.CreateXmlDeclaration("1.0", null, null));
            requestExXmlDoc.AppendChild(requestExXmlDoc.CreateProcessingInstruction("qbxml", "version=\"8.0\""));
            XmlElement outerEx = requestExXmlDoc.CreateElement("QBXML");
            requestExXmlDoc.AppendChild(outerEx);
            XmlElement innerEx = requestExXmlDoc.CreateElement("QBXMLMsgsRq");
            outerEx.AppendChild(innerEx);
            innerEx.SetAttribute("onError", "stopOnError");
            ExpenseQueryRq(requestExXmlDoc, innerEx);

            //Profit and Loss
            XmlDocument requestPLXmlDoc = new XmlDocument();
            requestPLXmlDoc.AppendChild(requestPLXmlDoc.CreateXmlDeclaration("1.0", null, null));
            requestPLXmlDoc.AppendChild(requestPLXmlDoc.CreateProcessingInstruction("qbxml", "version=\"8.0\""));
            XmlElement outerPL = requestPLXmlDoc.CreateElement("QBXML");
            requestPLXmlDoc.AppendChild(outerPL);
            XmlElement innerPL = requestPLXmlDoc.CreateElement("QBXMLMsgsRq");
            outerPL.AppendChild(innerPL);
            innerPL.SetAttribute("onError", "stopOnError");
            ProfitAndLossQueryRq(requestPLXmlDoc, innerPL);

            rp.OpenConnection2("", "QuickBooks Connector", QBXMLRPConnectionType.localQBD);

            connectionOpen = true;
            string ticket = "";
            //try
            //{

                //ticket = rp.BeginSession("C:\\Users\\Public\\Documents\\Intuit\\QuickBooks\\Company Files\\PIYPQB.QBW", QBFileMode.qbFileOpenSingleUser);

                ticket = rp.BeginSession("", QBFileMode.qbFileOpenDoNotCare);

                //if (Config.ConfigVars["qbfilename"].ToString() != "")
                //    ticket = rp.BeginSession(Config.ConfigVars["qbfilename"].ToString(), QBFileMode.qbFileOpenSingleUser);
                //else
                //    ticket = rp.BeginSession("", QBFileMode.qbFileOpenDoNotCare);

            //}
            //catch (Exception e)
            //{
            //    Helper.Log.Write("Message " + e.Message);
            //}

                sessionBegun = true;

            //Send the request and get the response from QuickBooks
             responseStrEx = rp.ProcessRequest(ticket, requestExXmlDoc.OuterXml);
             responseStrPL = rp.ProcessRequest(ticket, requestPLXmlDoc.OuterXml);

            //End the session and close the connection to QuickBooks
            rp.EndSession(ticket);
            sessionBegun = false;
            rp.CloseConnection();
            connectionOpen = false;


        //}
        //    catch (Exception e)
        //    {
        //        Helper.Log.Write(e.Message);
        //    }
}
        
        void ProfitAndLossQueryRq(XmlDocument doc, XmlElement parent)
        {
            XmlElement GeneralSummaryReportQueryRq = doc.CreateElement("GeneralSummaryReportQueryRq");
            parent.AppendChild(GeneralSummaryReportQueryRq);
            GeneralSummaryReportQueryRq.AppendChild(MakeSimpleElem(doc, "GeneralSummaryReportType", "ProfitAndLossStandard"));         

           GeneralSummaryReportQueryRq.AppendChild(MakeSimpleElem(doc, "ReportDateMacro", "All"));
            GeneralSummaryReportQueryRq.AppendChild(MakeSimpleElem(doc, "SummarizeColumnsBy", "Month"));
        }

        void ExpenseQueryRq(XmlDocument doc, XmlElement parent)
        {
            XmlElement AccountQueryRq = doc.CreateElement("AccountQueryRq");
            parent.AppendChild(AccountQueryRq);

            AccountQueryRq.AppendChild(MakeSimpleElem(doc, "AccountType", "Expense"));
        }

        public void ProfitAndLossQueryRs(string response)
        {
            //Parse the response XML string into an XmlDocument
            XmlDocument responseXmlDoc = new XmlDocument();
            responseXmlDoc.LoadXml(response);

            //Get the response for our request
            XmlNodeList GeneralSummaryReportQueryRsList = responseXmlDoc.GetElementsByTagName("GeneralSummaryReportQueryRs");
            if (GeneralSummaryReportQueryRsList.Count == 1) //Should always be true since we only did one request in this sample
            {
                XmlNode responseNode = GeneralSummaryReportQueryRsList.Item(0);
                XmlAttributeCollection rsAttributes = responseNode.Attributes;
                string statusCode = rsAttributes.GetNamedItem("statusCode").Value;

                //status code = 0 all OK, > 0 is warning
                if (Convert.ToInt32(statusCode) >= 0)
                {
                    XmlNodeList ReportRetList = responseNode.SelectNodes("//ReportRet");//XPath Query
                    for (int i = 0; i < ReportRetList.Count; i++)
                    {
                        XmlNode ReportRet = ReportRetList.Item(i);
                        ProfitAndLossRet(ReportRet);
                    }
                }
            }
        }


        void ProfitAndLossRet(XmlNode ReportRet)
        {
            if (ReportRet == null) return;
            XmlNodeList ColDescList = ReportRet.SelectNodes("./ColDesc");
            List<IncomeExpense> PLBs = new List<IncomeExpense>();
            string monthName = "";
            List<string> months = new List<string>();
            if (ColDescList != null)
            {
                for (int i = 0; i < ColDescList.Count; i++)
                {
                    XmlNode ColDesc = ColDescList.Item(i);
                    //Walk list of ColTitle aggregates
                    XmlNodeList ColTitleList = ColDesc.SelectNodes("./ColTitle");

                    if (ColTitleList != null)
                    {
                        for (int j = 0; j < ColTitleList.Count; j++)
                        {
                            XmlNode ColTitle = ColTitleList.Item(j);

                            XmlAttributeCollection rsAttributes = ColTitle.Attributes;

                            if (rsAttributes.GetNamedItem("value") != null)
                            {
                                if (rsAttributes.GetNamedItem("value").Value != "TOTAL")
                                {

                                    monthName = rsAttributes.GetNamedItem("value").Value;
                                    //Helper.Log.Write(monthName.Length.ToString());
                                    if (monthName.Length > 6)
                                    {
                                        monthName = monthName.Substring(0, 4) + monthName.Substring(monthName.Length - 2);
                                    }
                                    months.Add(monthName);
                                }
                            }
                        }
                    }

                }
            }

            //Get all field values for ReportData aggregate
            XmlNode ReportData = ReportRet.SelectSingleNode("./ReportData");
            if (ReportData != null)
            {
                XmlNodeList ORReportDataListChildren = ReportRet.SelectNodes("./ReportData/*");
                string AccountType = "";
                for (int i = 0; i < ORReportDataListChildren.Count; i++)
                {
                    XmlNode Child = ORReportDataListChildren.Item(i);

                    if (Child.Name == "TextRow")
                    {
                        AccountType = Child.Attributes["value"].Value;
                    }

                    else if (Child.Name == "DataRow")
                    {
                        //Get all field values for RowData aggregate
                        XmlNode RowData = Child.SelectSingleNode("./RowData");
                        if (RowData != null)
                        {
                            if (RowData.Attributes["rowType"] != null && RowData.Attributes["rowType"].Value == "account")
                            {
                                //Helper.Log.Write(RowData.Attributes["value"].Value);

                                XmlNodeList ColDataList = Child.SelectNodes("./ColData");
                                if (ColDataList != null)
                                {

                                    for (int j = 1; j < ColDataList.Count - 1; j++)
                                    {
                                        if(ColDataList.Item(j).Attributes["value"].Value != "0.00")
                                        { 
                                            PLBs.Add(new IncomeExpense() { Account = RowData.Attributes["value"].Value, Amount = ColDataList.Item(j).Attributes         ["value"].Value, Month = months[j - 1], AccountType = AccountType });
                                        }
                                        //Helper.Log.Write(ColDataList.Item(j).Attributes["value"].Value);
                                    }

                                }
                            }
                        }
                    }

                }

                if (PLBs.Count > 0)
                {
                    string ProfitAndLossJsonData = JsonConvert.SerializeObject(PLBs, Newtonsoft.Json.Formatting.None, new IsoDateTimeConverter() { DateTimeFormat = "yyyy-MM-dd HH:mm:ss" });

                    ProfitAndLossJsonData = ProfitAndLossJsonData.Replace("0001-01-01 00:00:00", "");
                    SendProfitAndLossJsonData(ProfitAndLossJsonData);
                    Helper.Log.Write("ProfitAndLossJsonData " + ProfitAndLossJsonData);

                }
            }
        }

        public void ExpenseQueryRs(string response)
        {
            Helper.Log.Write("1");
            XmlDocument responseXmlDoc = new XmlDocument();
            responseXmlDoc.LoadXml(response);

            Helper.Log.Write("2");

            //Get the response for our request
            XmlNodeList AccountQueryRsList = responseXmlDoc.GetElementsByTagName("AccountQueryRs");
            if (AccountQueryRsList.Count == 1) //Should always be true since we only did one request in this sample
            {
                Helper.Log.Write("3");
                XmlNode responseNode = AccountQueryRsList.Item(0);
                XmlAttributeCollection rsAttributes = responseNode.Attributes;
                string statusCode = rsAttributes.GetNamedItem("statusCode").Value;

                //status code = 0 all OK, > 0 is warning
                if (Convert.ToInt32(statusCode) >= 0)
                {
                    Helper.Log.Write("4");
                    XmlNodeList AccountRetList = responseNode.SelectNodes("//AccountRet");//XPath Query
                    for (int i = 0; i < AccountRetList.Count; i++)
                    {
                        XmlNode AccountRet = AccountRetList.Item(i);
                        ExpenseRet(AccountRet);
                    }
                }
            }
        }

        void ExpenseRet(XmlNode AccountRet)
        {
            if (AccountRet == null) return;

            Helper.Log.Write("5");

            IList<ExpensesBase> lstExpPromo = new List<ExpensesBase>();

            lstExpPromo.Add(ParseXMLData(AccountRet));
           
            if (lstExpPromo.Count > 0)
            {
                string ExpenseJsonData = JsonConvert.SerializeObject(lstExpPromo, Newtonsoft.Json.Formatting.None, new IsoDateTimeConverter() { DateTimeFormat = "yyyy-MM-dd HH:mm:ss" });

                ExpenseJsonData = ExpenseJsonData.Replace("0001-01-01 00:00:00", "");
                SendExpenseJsonData(ExpenseJsonData);
                Helper.Log.Write("ExpenseJsonData " + ExpenseJsonData);
            }
        }        

        private ExpensesBase ParseXMLData(XmlNode AccountRet)
        {
            ExpensesBase EBase = new ExpensesBase();             

            EBase.Name = AccountRet.SelectSingleNode("./Name").InnerText;
            EBase.ListID = AccountRet.SelectSingleNode("./ListID").InnerText;

            string TimeCreated = AccountRet.SelectSingleNode("./TimeCreated").InnerText;
            if (TimeCreated != "")
            {
                EBase.TimeCreated = Convert.ToDateTime(TimeCreated);
            }

            string TimeModified = AccountRet.SelectSingleNode("./TimeModified").InnerText;
            if (TimeModified != "")
            {
                EBase.TimeModified = Convert.ToDateTime(TimeModified);
            }

            EBase.EditSequence = AccountRet.SelectSingleNode("./EditSequence").InnerText;
            EBase.FullName = AccountRet.SelectSingleNode("./FullName").InnerText;

            if (AccountRet.SelectSingleNode("./IsActive") != null)
            {
                string IsActive = AccountRet.SelectSingleNode("./IsActive").InnerText;
                if (IsActive != "")
                {
                    EBase.IsActive = Convert.ToBoolean(IsActive);
                }
            }

            XmlNode ParentRef = AccountRet.SelectSingleNode("./ParentRef");
            if (ParentRef != null)
            {
                if (AccountRet.SelectSingleNode("./ParentRef/ListID") != null)
                {
                    EBase.ParentRefListID = AccountRet.SelectSingleNode("./ParentRef/ListID").InnerText;
                }
                if (AccountRet.SelectSingleNode("./ParentRef/FullName") != null)
                {
                    EBase.ParentRefFullName = AccountRet.SelectSingleNode("./ParentRef/FullName").InnerText;
                }
            }

            string Sublevel = AccountRet.SelectSingleNode("./Sublevel").InnerText;
            if (Sublevel != "")
            {
                EBase.Sublevel = Convert.ToInt32(Sublevel);
            }

            EBase.AccountType = AccountRet.SelectSingleNode("./AccountType").InnerText;
            if (AccountRet.SelectSingleNode("./SpecialAccountType") != null)
            {
                EBase.SpecialAccountType = AccountRet.SelectSingleNode("./SpecialAccountType").InnerText;
            }
            if (AccountRet.SelectSingleNode("./AccountNumber") != null)
            {
                string AccountNumber = AccountRet.SelectSingleNode("./AccountNumber").InnerText;
                if (AccountNumber != "")
                {
                    EBase.AccountNumber = Convert.ToInt32(AccountNumber);
                }
            }
            if (AccountRet.SelectSingleNode("./BankNumber") != null)
            {
                EBase.BankNumber = AccountRet.SelectSingleNode("./BankNumber").InnerText;
            }
            if (AccountRet.SelectSingleNode("./Desc") != null)
            {
                EBase.Desc = AccountRet.SelectSingleNode("./Desc").InnerText;
            }
            if (AccountRet.SelectSingleNode("./Balance") != null)
            {
                string Balance = AccountRet.SelectSingleNode("./Balance").InnerText;
                if (Balance != "")
                {
                    EBase.Balance = Convert.ToDecimal(Balance);
                }
            }
            if (AccountRet.SelectSingleNode("./TotalBalance") != null)
            {
                string TotalBalance = AccountRet.SelectSingleNode("./TotalBalance").InnerText;
                if (TotalBalance != "")
                {
                    EBase.TotalBalance = Convert.ToDecimal(TotalBalance);
                }
            }
            XmlNode TaxLineInfoRet = AccountRet.SelectSingleNode("./TaxLineInfoRet");
            if (TaxLineInfoRet != null)
            {
                string TaxLineID = AccountRet.SelectSingleNode("./TaxLineInfoRet/TaxLineID").InnerText;
                if (AccountRet.SelectSingleNode("./TaxLineInfoRet/TaxLineName") != null)
                {
                    EBase.TaxLineName = AccountRet.SelectSingleNode("./TaxLineInfoRet/TaxLineName").InnerText;
                }
            }
            if (AccountRet.SelectSingleNode("./CashFlowClassification") != null)
            {
                EBase.CashFlowClassification = AccountRet.SelectSingleNode("./CashFlowClassification").InnerText;
            }
            return EBase;
        }

        private void SendExpenseJsonData(string ExpensesJsonData)
        {
            var client = new RestClient(Config.ConfigVars["api_url_base"].ToString());
            var request = new RestRequest(Config.ConfigVars["api_url_expenses_add"].ToString(), Method.POST);
            request.AddParameter("api_key", Config.ConfigVars["api_key"].ToString(), ParameterType.GetOrPost);

            request.AddParameter("data", ExpensesJsonData, ParameterType.GetOrPost);

            IRestResponse response = client.Execute(request);

            Helper.Log.Write(response.Content);
        }

        private void SendProfitAndLossJsonData(string ProfitAndLossJsonData)
        {
            var client = new RestClient(Config.ConfigVars["api_url_base"].ToString());
            var request = new RestRequest(Config.ConfigVars["api_url_profitloss_add"].ToString(), Method.POST);
            request.AddParameter("api_key", Config.ConfigVars["api_key"].ToString(), ParameterType.GetOrPost);

            request.AddParameter("data", ProfitAndLossJsonData, ParameterType.GetOrPost);

            IRestResponse response = client.Execute(request);

            Helper.Log.Write(response.Content);
        }
    }
}