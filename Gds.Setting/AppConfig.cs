using System.Configuration;

namespace Gds.Setting
{
    public class AppConfig
    {
        public static string UploadFolder
        {
            get { return ConfigurationManager.AppSettings["UploadFolder"]; }
        }
    }
}
