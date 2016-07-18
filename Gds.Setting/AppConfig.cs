using System.Configuration;

namespace Gds.Setting
{
    public class AppConfig
    {
        public static string UploadFolder
        {
            get { return ConfigurationManager.AppSettings["UploadFolder"]; }
        }

        public static string AppIdFb 
        {
            get { return ConfigurationManager.AppSettings["FacebookId"]; }
        }

        public static string AppSecretFb
        {
            get { return ConfigurationManager.AppSettings["FacebookAppSecret"]; }
        }

        public static string AppIdGG
        {
            get { return ConfigurationManager.AppSettings["GoogleId"]; }
        }

        public static string AppSecretGG
        {
            get { return ConfigurationManager.AppSettings["GoogleSecret"]; }
        }
    }
}
