using System;
using System.Drawing;
using System.Windows.Forms;

namespace QuickBooksIntegration
{
    public partial class SearchSuccess : Form
    {   
        public SearchSuccess()
        {
            InitializeComponent();
        }

        private void SearchSuccess_Load(object sender, EventArgs e)
        {
            lblSuccess.ForeColor = Color.FromArgb(131, 190, 63);
            btnContinue.FlatAppearance.MouseOverBackColor = Color.White;
            btnCancel.FlatAppearance.MouseOverBackColor = Color.White;
            btnContinue.Cursor = Cursors.Hand;
            btnCancel.Cursor = Cursors.Hand;
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            this.Close();
            FileBrowse FB = new FileBrowse();
            FB.ShowDialog();
            // Sync SF = new Sync();
            //SF.ShowDialog();
        }



        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
