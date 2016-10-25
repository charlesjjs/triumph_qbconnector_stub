using Microsoft.Win32;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Windows.Forms;
using System.Xml;

namespace QuickBooksIntegration
{
    public partial class Main : Form
    {   
        public Main()
        {
            InitializeComponent();
        }       

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            Config.InitConfig();
            LoadFunctions();

            //if (Config.ConfigVars["api_key"].ToString() == "")
            //{
            //    SplashScreen SS = new SplashScreen();
            //    SS.WindowState = FormWindowState.Normal;
            //    SS.ShowDialog();
            //}

            //backgroundWorker1.RunWorkerAsync();

            

            ////if(QBValidations())
            ////{
            ////     backgroundWorker1.RunWorkerAsync();     
            ////}

            ///////SYNC COMPLETE
            //////lblSync.Visible = false;
            //////crProgress.SuperscriptText = "";
            //////crProgress.Text = "SYNC" + "\n" + "COMPLETE";
            //////crProgress.Font = new Font("Century Gothic", 11, FontStyle.Bold);
            //////crProgress.TextMargin = new Padding(2,3, 0, 0);


            ///////Data Error
            //////lblSync.Visible = false;
            //////crProgress.SuperscriptText = "";
            //////crProgress.Text = "ERROR";
            //////crProgress.Font = new Font("Century Gothic", 11, FontStyle.Bold);
            //////crProgress.TextMargin = new Padding(2, 3, 0, 0);
            //////crProgress.ForeColor = Color.FromArgb(239, 54, 55);
            //////crProgress.OuterColor = Color.FromArgb(239, 54, 55);
            //////lblQBConnected.Text = "Error with DATA";
            //////lblQBConnected.ForeColor = Color.FromArgb(239, 54, 55);
            //////lblQBConnected.Location = new Point(50, 103);
        }

        private bool QBValidations()
        {
            bool connection = NetworkInterface.GetIsNetworkAvailable();
            if (connection == true)
            {
                if (CheckForApiKeyValidity(txtAPIKey.Text))
                {
                    if (checkInstalled("QuickBooks"))
                    {
                        return true;
                    }
                    else
                    {
                        QuickBooksInavilable();
                        return false;
                    }
                }
                else
                {
                    ApiKeyInvalid();
                    return false;
                }
            }
            else
            {
                NoInternetConnection();
                return false;
            }                 
        }

        private void QuickBooksInavilable()
        {
            lblSync.Visible = false;
            crProgress.SuperscriptText = "";
            crProgress.Text = "ERROR";
            crProgress.Font = new Font("Century Gothic", 11, FontStyle.Bold);
            crProgress.TextMargin = new Padding(2, 3, 0, 0);
            crProgress.ForeColor = Color.FromArgb(239, 54, 55);
            crProgress.OuterColor = Color.FromArgb(239, 54, 55);
            lblQBConnected.Text = "Quickbooks" + "\n" + "Inavailable";
            lblQBConnected.ForeColor = Color.FromArgb(239, 54, 55);
            lblQBConnected.Location = new Point(50, 103);
        }

        public static bool checkInstalled(string c_name)
        {
            string displayName;

            string registryKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
            RegistryKey key = Registry.LocalMachine.OpenSubKey(registryKey);
            if (key != null)
            {
                foreach (RegistryKey subkey in key.GetSubKeyNames().Select(keyName => key.OpenSubKey(keyName)))
                {
                    displayName = subkey.GetValue("DisplayName") as string;
                    if (displayName != null && displayName.Equals(c_name))
                    {
                        return true;
                    }
                }
                key.Close();
            }

            registryKey = @"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall";
            key = Registry.LocalMachine.OpenSubKey(registryKey);
            if (key != null)
            {
                foreach (RegistryKey subkey in key.GetSubKeyNames().Select(keyName => key.OpenSubKey(keyName)))
                {
                    displayName = subkey.GetValue("DisplayName") as string;
                    if (displayName != null && displayName.Equals(c_name))
                    {
                        return true;
                    }

                }
                key.Close();
            }
            return false;
        }

        private void NoInternetConnection()
        {            
            lblSync.Visible = false;
            crProgress.SuperscriptText = "";
            crProgress.Text = "ERROR";
            crProgress.Font = new Font("Century Gothic", 11, FontStyle.Bold);
            crProgress.TextMargin = new Padding(2, 3, 0, 0);
            crProgress.ForeColor = Color.FromArgb(239, 54, 55);
            crProgress.OuterColor = Color.FromArgb(239, 54, 55);
            lblPiYPConnected.Text = "No Internet " + "\n" + "Connection";
            lblPiYPConnected.ForeColor = Color.FromArgb(239, 54, 55);
        }

        private void LoadFunctions()
        {
            lblQBConnected.ForeColor = Color.FromArgb(151, 199, 98);
            lblPiYPConnected.ForeColor = Color.FromArgb(151, 199, 98);
            pnlMain.ForeColor = Color.FromArgb(215, 215, 215);


            crProgress.ProgressColor = Color.FromArgb(194, 88, 142);
            crProgress.OuterColor = Color.FromArgb(238, 214, 226);
            crProgress.ForeColor = Color.FromArgb(194, 88, 142);
            crProgress.SuperscriptColor = Color.FromArgb(194, 88, 142);

            lblSync.ForeColor = Color.FromArgb(194, 88, 142);
            txtAPIKey.BorderStyle = BorderStyle.None;

            lblExitConfirmation.Cursor = Cursors.Hand;

            if (Config.ConfigVars["api_key"].ToString() != "")
                txtAPIKey.Text = Config.ConfigVars["api_key"].ToString();


            crProgress.Value = 0;
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {  

            string responseStrEx = "";
            string responseStrPL = "";

            BeginInvoke((MethodInvoker)delegate
            {
                crProgress.Text = "10";
                crProgress.Value = 10;
            });

            PushData PD = new PushData();
            PD.Export(out responseStrEx, out responseStrPL);

            BeginInvoke((MethodInvoker)delegate
            {
                crProgress.Text = "40";                
                crProgress.Value = 40;
            });

            PD.ExpenseQueryRs(responseStrEx);

            BeginInvoke((MethodInvoker)delegate
            {
                crProgress.Text = "70";
                crProgress.Value = 70;
            });

            PD.ProfitAndLossQueryRs(responseStrPL);

            BeginInvoke((MethodInvoker)delegate
            {
                crProgress.Text = "100";
                crProgress.Value = 100;
            });
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if(btnEdit.Text == "EDIT")
            { 
            txtAPIKey.BorderStyle = BorderStyle.Fixed3D;
            btnEdit.Text = "SAVE";
            }
            else
            {
                SaveAPIkey();
                txtAPIKey.BorderStyle = BorderStyle.None;
                btnEdit.Text = "EDIT";
                
            }
        }


        private void SaveAPIkey()
        {
            string PIYPApiKey = txtAPIKey.Text;

            if (PIYPApiKey != "" && CheckForApiKeyValidity(PIYPApiKey))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(Config.GetConfigFilePath());
                foreach (XmlNode node in doc.DocumentElement.ChildNodes)
                {
                    if (node.Attributes["key"].Value == "api_key")
                    {
                        node.Attributes["value"].Value = PIYPApiKey;
                    }
                }

                doc.Save(Config.GetConfigFilePath());

                ApiKeyValid();

                backgroundWorker1.RunWorkerAsync();
            }
            else
            {
                ApiKeyInvalid();
            }
        }

        private void ApiKeyInvalid()
        {            
            lblSync.Visible = false;
            crProgress.SuperscriptText = "";
            crProgress.Text = "ERROR";
            crProgress.Font = new Font("Century Gothic", 11, FontStyle.Bold);
            crProgress.TextMargin = new Padding(2, 3, 0, 0);
            crProgress.ForeColor = Color.FromArgb(239, 54, 55);
            crProgress.OuterColor = Color.FromArgb(239, 54, 55);
            lblPiYPConnected.Text = "API Key Invalid";
            lblPiYPConnected.ForeColor = Color.FromArgb(239, 54, 55);
            lblPiYPConnected.Location = new Point(363, 103);
        }

        private void ApiKeyValid()
        {
            lblSync.Visible = true;
            crProgress.SuperscriptText = "%";
            crProgress.Text = "0";
            crProgress.Font = new Font("Century Gothic", 26, FontStyle.Bold);
            crProgress.TextMargin = new Padding(4, -4, 0, 0);
            crProgress.ProgressColor = Color.FromArgb(194, 88, 142);
            crProgress.OuterColor = Color.FromArgb(238, 214, 226);            
            crProgress.ForeColor = Color.FromArgb(194, 88, 142);
            crProgress.SuperscriptColor = Color.FromArgb(194, 88, 142);

            lblPiYPConnected.Text = "Connected";
            lblPiYPConnected.ForeColor = Color.FromArgb(151, 199, 98);
            lblPiYPConnected.Location = new Point(376, 103);
        }

        private bool CheckForApiKeyValidity(string PiypApiKey)
        {
            try
            {
                var client = new RestClient(Config.ConfigVars["api_url_base"].ToString());
                var request = new RestRequest(Config.ConfigVars["api_key_validity"].ToString(), Method.POST);

                request.AddParameter("api_key", PiypApiKey, ParameterType.GetOrPost);
                IRestResponse response = client.Execute(request);

                dynamic stuff = JsonConvert.DeserializeObject(response.Content);

                return stuff.status;
            }
            catch
            {
                return false;
            }
        }

        private void lblExitConfirmation_Click(object sender, EventArgs e)
        {            
            ExitConfirmation EC = new ExitConfirmation();
            EC.ShowDialog();
        }
    }
}
