using Microsoft.Win32;
using System;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Windows.Forms;

namespace QuickBooksIntegration
{
    public partial class Progress : Form
    {   
        public Progress()
        {
            InitializeComponent();
        }

        private void Progress_Load(object sender, EventArgs e)
        {
            btnContinue.FlatAppearance.MouseOverBackColor = Color.White;
            btnCancel.FlatAppearance.MouseOverBackColor = Color.White;
            btnContinue.Cursor = Cursors.Hand;
            btnCancel.Cursor = Cursors.Hand;
            backgroundWorker1.RunWorkerAsync();
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            this.Close();

          
                if (checkInstalled("QuickBooks"))
                {
                    SearchSuccess SS = new SearchSuccess();
                    SS.ShowDialog();
                }
                else
                {
                    SearchFail SF = new SearchFail();
                    SF.ShowDialog();
                }
           
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

        private void RunProgress()
        {
            int i;
            ProBar.Minimum = 0;
            ProBar.Maximum = 2000;

            for (i = 0; i <= 2000; i++)
            {
                System.Threading.Thread.Sleep(10);
                ProBar.Value = i;
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

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            { 
                for (int i = 1; i < 100; i++)
                {
                    // Wait 100 milliseconds.
                    System.Threading.Thread.Sleep(10);
                    BeginInvoke((MethodInvoker)delegate
                    {
                        ProBar.Value = i;
                    });
                }
            }
            catch
            {               
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {            
            ProBar.Value = e.ProgressPercentage;            
            this.Text = e.ProgressPercentage.ToString();
        }
    }
}
