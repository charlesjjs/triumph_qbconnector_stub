using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace QuickBooksIntegration.Helper
{
    class Log
    {
        public static void Write(string LogTxt)
        {

            StreamWriter sw;
            if (File.Exists(Config.AppBaseDirectory + "\\Logs\\Log.txt"))
            {
                sw = new StreamWriter(Config.AppBaseDirectory + "\\Logs\\Log.txt", true);
            }
            else
            {
                sw = new StreamWriter(Config.AppBaseDirectory + "\\Logs\\Log.txt");
            }
            sw.Write("\n" + DateTime.Now.ToString("yyyy-MM-dd H:m:s") + ": " + LogTxt);
            sw.Close();
        }
    }
}
