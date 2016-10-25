using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

namespace QuickBooksIntegration
{
    public partial class FileBrowse : Form
    {       

        public FileBrowse()
        {
            InitializeComponent();
        }

        private void FileBrowse_Load(object sender, EventArgs e)
        {
            btnBrowse.FlatAppearance.MouseOverBackColor = Color.White;
            btnContinue.FlatAppearance.MouseOverBackColor = Color.White;
            btnCancel.FlatAppearance.MouseOverBackColor = Color.White;

             btnBrowse.Cursor = Cursors.Hand;
            btnContinue.Cursor = Cursors.Hand;
            btnCancel.Cursor = Cursors.Hand;

            lblQBFileInvalid.Visible = false;

           // txtQBFileName.Text = "C:\\Users\\Public\\Documents\\Intuit\\QuickBooks\\Company Files\\PIYPQB.QBW";
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {    
            if (txtQBFileName.Text != "")
            { 
                XmlDocument doc = new XmlDocument();
                doc.Load(Config.GetConfigFilePath());
                foreach (XmlNode node in doc.DocumentElement.ChildNodes)
                {
                    if (node.Attributes["key"].Value == "qbfilename")
                    {
                        node.Attributes["value"].Value = txtQBFileName.Text;                        
                    }
                }
                doc.Save(Config.GetConfigFilePath());

                this.Close();
                Sync MF = new Sync();
                MF.ShowDialog();
            }
            else
            {
                lblQBFileInvalid.Visible = true;
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

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog choofdlog = new OpenFileDialog();
            choofdlog.Filter = "All Files (*.*)|*.*";
            choofdlog.FilterIndex = 1;
            choofdlog.Multiselect = true;            

            if (choofdlog.ShowDialog() == DialogResult.OK)
            {
                string sFileName = choofdlog.FileName;
                txtQBFileName.Text = sFileName;
            }
        }
    }
}
