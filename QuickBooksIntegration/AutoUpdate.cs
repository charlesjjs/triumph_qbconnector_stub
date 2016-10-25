using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace QuickBooksIntegration
{
    public partial class AutoUpdate : Form
    {   
        public AutoUpdate()
        {
            InitializeComponent();
        }

        private void Sync_Load(object sender, EventArgs e)
        {
            btnContinue.FlatAppearance.MouseOverBackColor = Color.White;           
            btnContinue.Cursor = Cursors.Hand;           
        }      

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }        

        private void btnContinue_Click(object sender, EventArgs e)
        {
            this.Close();
            Main MN = new Main();
            MN.ShowDialog();
        }        
    }
}
