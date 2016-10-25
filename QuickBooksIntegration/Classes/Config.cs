using System;
using System.Collections.Specialized;
using System.Xml;
using RestSharp;

namespace QuickBooksIntegration
{
    class Config
    {
        public static string AppBaseDirectory = "";

        public static NameValueCollection ConfigVars = new NameValueCollection();
        

        public static void InitConfig()
        {
            AppBaseDirectory = AppDomain.CurrentDomain.BaseDirectory;

            XmlDocument doc = new XmlDocument();
            doc.Load(AppBaseDirectory + "\\Config\\Config.xml");

            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                ConfigVars[node.Attributes["key"].Value] = node.Attributes["value"].Value;
            }
        }

        public static string GetConfigFilePath()
        {
            string ConfigFilePath = AppDomain.CurrentDomain.BaseDirectory + "\\Config\\Config.xml";

            return ConfigFilePath;
        }

       
    }
}
