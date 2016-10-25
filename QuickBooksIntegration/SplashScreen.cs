using Newtonsoft.Json;
using RestSharp;
using System;
using System.Drawing;
using System.Net.NetworkInformation;
using System.Windows.Forms;
using System.Xml;

namespace QuickBooksIntegration
{
    public partial class SplashScreen : Form
    {
        public SplashScreen()
        {
            InitializeComponent();
            Config.InitConfig();
        }

        private void Home_Load(object sender, EventArgs e)
        {          
            btnBegin.FlatAppearance.MouseOverBackColor = Color.White;
            btnBegin.Cursor = Cursors.Hand;            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnBegin_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home hm = new Home();
            hm.ShowDialog();
        }

       


    }
}
