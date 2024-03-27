using Microsoft.Extensions.Configuration;

namespace CrimeReportingSystem.Utility
{
    internal class DBConnectUtil
    {
        private static IConfiguration iconfiguration;

        static DBConnectUtil()
        {
            GetAppSettingsFile();
        }

        private static void GetAppSettingsFile()
        {
            var builder = new ConfigurationBuilder().SetBasePath
                (Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            iconfiguration = builder.Build();
        }

        public static string GetConnectionString()
        {
            return iconfiguration.GetConnectionString("LocalConnectionString");
        }
    }
}



