using System;
using System.Configuration;

namespace Edi.Advance.BTEC.UiTests.Framework
{
    public sealed class Configuration
    {
        public static string SiteUrl
        {
            get { return ConfigurationManager.AppSettings["SiteUrl"]; }
        }

        public static TimeSpan Timeout
        {
            get { return TimeSpan.FromMilliseconds(double.Parse(ConfigurationManager.AppSettings["Timeout"])); }
        }

        public static string DownloadDir
        {
            get { return ConfigurationManager.AppSettings["DownloadDir"]; }
        }

        public static string Browser
        {
            get { return ConfigurationManager.AppSettings["Browser"]; }
        }

        public static string HubUrl
        {
            get { return ConfigurationManager.AppSettings["HubUrl"]; }
        }
    }
}