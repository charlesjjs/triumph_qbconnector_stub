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
    class Test
    {
        private XmlElement MakeSimpleElem(XmlDocument doc, string tagName, string tagVal)
        {
            XmlElement elem = doc.CreateElement(tagName);
            elem.InnerText = tagVal;
            return elem;
        }

        public void Export()
        {
            bool sessionBegun = false;
            bool connectionOpen = false;
            RequestProcessor2 rp = null;

            //Create the Request Processor object
            rp = new RequestProcessor2();

            //Create the XML document to hold our request
            XmlDocument requestXmlDoc = new XmlDocument();
            //Add the prolog processing instructions
            requestXmlDoc.AppendChild(requestXmlDoc.CreateXmlDeclaration("1.0", null, null));
            requestXmlDoc.AppendChild(requestXmlDoc.CreateProcessingInstruction("qbxml", "version=\"8.0\""));

            //Create the outer request envelope tag
            XmlElement outer = requestXmlDoc.CreateElement("QBXML");
            requestXmlDoc.AppendChild(outer);

            //Create the inner request envelope & any needed attributes
            XmlElement inner = requestXmlDoc.CreateElement("QBXMLMsgsRq");
            outer.AppendChild(inner);
            inner.SetAttribute("onError", "stopOnError");
            BuildGeneralDetailReportQueryRq(requestXmlDoc, inner);

            //Connect to QuickBooks and begin a session
            rp.OpenConnection2("", "Sample Code from OSR", QBXMLRPConnectionType.localQBD);
            connectionOpen = true;
            //string ticket = rp.BeginSession("", QBFileMode.qbFileOpenDoNotCare);
            string ticket = rp.BeginSession("C:\\Users\\Public\\Documents\\Intuit\\QuickBooks\\Company Files\\PIYPQB.QBW", QBFileMode.qbFileOpenSingleUser);
            sessionBegun = true;

            //Send the request and get the response from QuickBooks
            string responseStr = rp.ProcessRequest(ticket, requestXmlDoc.OuterXml);

            //End the session and close the connection to QuickBooks
            rp.EndSession(ticket);
            sessionBegun = false;
            rp.CloseConnection();
            connectionOpen = false;

            WalkGeneralDetailReportQueryRs(responseStr);

        }

        void BuildGeneralDetailReportQueryRq(XmlDocument doc, XmlElement parent)
        {
            XmlElement GeneralSummaryReportQueryRq = doc.CreateElement("GeneralSummaryReportQueryRq");
            parent.AppendChild(GeneralSummaryReportQueryRq);
            GeneralSummaryReportQueryRq.AppendChild(MakeSimpleElem(doc, "GeneralSummaryReportType", "ProfitAndLossStandard"));

            string ORElementType = "ReportPeriod";
            if (ORElementType == "ReportPeriod")
            {
                XmlElement ReportPeriod = doc.CreateElement("ReportPeriod");
                GeneralSummaryReportQueryRq.AppendChild(ReportPeriod);
                ReportPeriod.AppendChild(MakeSimpleElem(doc, "FromReportDate", "2015-01-01"));
                ReportPeriod.AppendChild(MakeSimpleElem(doc, "ToReportDate", "2016-10-22"));
            }

            //GeneralSummaryReportQueryRq.AppendChild(MakeSimpleElem(doc, "ReportDateMacro", "All"));
            GeneralSummaryReportQueryRq.AppendChild(MakeSimpleElem(doc, "SummarizeColumnsBy", "Month"));

        }

        void WalkGeneralDetailReportQueryRs(string response)
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
                        WalkReportRet(ReportRet);
                    }
                }
            }
        }



        void WalkReportRet(XmlNode ReportRet)
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
                                        PLBs.Add(new IncomeExpense() { Account = RowData.Attributes["value"].Value, Amount = ColDataList.Item(j).Attributes["value"].Value, Month = months[j - 1], AccountType = AccountType });



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
                    Helper.Log.Write("ProfitAndLossJsonData " + ProfitAndLossJsonData);

                }
            }
        }
    }
}