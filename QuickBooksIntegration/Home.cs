using Newtonsoft.Json;
using RestSharp;
using System;
using System.Drawing;
using System.Net.NetworkInformation;
using System.Windows.Forms;
using System.Xml;

namespace QuickBooksIntegration
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
            Config.InitConfig();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            btnPaste.FlatAppearance.MouseOverBackColor = Color.White;
            btnContinue.FlatAppearance.MouseOverBackColor = Color.White;
            btnCancel.FlatAppearance.MouseOverBackColor = Color.White;

            btnPaste.Cursor = Cursors.Hand;
            btnContinue.Cursor = Cursors.Hand;
            btnCancel.Cursor = Cursors.Hand;

            lblApiKeyInvalid.Visible = false;
            lblApiKeyValid.Visible = false;
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            SaveAPIkey();

            this.Close();
            SearchSuccess SS = new SearchSuccess();
            SS.ShowDialog();
        }

       

        private void SaveAPIkey()
        {
            string PIYPApiKey = txtApiKey.Text;

            if (PIYPApiKey != "" && CheckForApiKeyValidity(PIYPApiKey))
            {
                lblApiKeyInvalid.Visible = false;
                lblApiKeyValid.Visible = true;

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
                this.Hide();
                //Progress PB = new Progress();
                //PB.ShowDialog();                

            }
            else
            {
                lblApiKeyInvalid.Visible = true;
                lblApiKeyValid.Visible = false;
            }
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

      

        private void btnPaste_Click(object sender, EventArgs e)
        {
            if (btnPaste.Text == "Paste")
            {
                txtApiKey.Paste();
                btnPaste.Text = "REMOVE";
                btnPaste.ForeColor = Color.Red;
            }
            else
            {
                txtApiKey.Clear();
                btnPaste.Text = "Paste";
                btnPaste.ForeColor = Color.FromArgb(72, 200, 239);
            }
        }

       
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();           
        }

        private void txtApiKey_TextChanged(object sender, EventArgs e)
        {
            if (txtApiKey.Text != "")
            {
                btnPaste.Text = "REMOVE";
                btnPaste.ForeColor = Color.Red;
            }
            else
            {
                btnPaste.Text = "Paste";
                btnPaste.ForeColor = Color.FromArgb(72, 200, 239);
            }
        }

        
    }
}
