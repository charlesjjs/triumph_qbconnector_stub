using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace QuickBooksIntegration
{
    public partial class ExitConfirmation : Form
    {   
        public ExitConfirmation()
        {
            InitializeComponent();
        }

        private void Sync_Load(object sender, EventArgs e)
        {
            btnNo.FlatAppearance.MouseOverBackColor = Color.White;           
            btnNo.Cursor = Cursors.Hand;
            lblConfirmation.ForeColor = Color.FromArgb(161,161,161);

            btnYes.FlatAppearance.MouseOverBackColor = Color.White;
            btnYes.Cursor = Cursors.Hand;
            btnYes.ForeColor = Color.FromArgb(242,102,81);
        }      

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }        

        private void btnContinue_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
