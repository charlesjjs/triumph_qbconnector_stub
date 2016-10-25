using System;
using System.Drawing;
using System.Windows.Forms;

namespace QuickBooksIntegration
{
    public partial class InternetFail : Form
    {   
        public InternetFail()
        {
            InitializeComponent();
        }

        private void InternetFail_Load(object sender, EventArgs e)
        {
            lblFail.ForeColor = Color.FromArgb(181, 169, 169);
            btnContinue.FlatAppearance.MouseOverBackColor = Color.White;
            btnCancel.FlatAppearance.MouseOverBackColor = Color.White;
            btnRetry.FlatAppearance.MouseOverBackColor = Color.White;

            btnContinue.Cursor = Cursors.Hand;
            btnCancel.Cursor = Cursors.Hand;
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            this.Close();
            Home HM = new Home();
            HM.ShowDialog();
        }

      

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnRetry_Click(object sender, EventArgs e)
        {
            this.Close();
            Home HM = new Home();
            HM.ShowDialog();
        }       
    }
}
