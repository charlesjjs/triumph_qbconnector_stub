using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace QuickBooksIntegration
{
    public partial class Sync : Form
    {   
        public Sync()
        {
            InitializeComponent();
        }

        private void Sync_Load(object sender, EventArgs e)
        {
            
        }      

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }      

        private void btnContinue_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main MN = new Main();
            MN.ShowDialog();
        }        
    }
}
