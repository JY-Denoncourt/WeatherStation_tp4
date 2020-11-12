using Microsoft.Extensions.Configuration;
using System.Windows;

namespace WeatherApp
{
    public static class AppConfiguration
    {
        private static IConfiguration configuration;

        private static void initConfig()
        {
            var builder = new ConfigurationBuilder();
            builder.AddJsonFile("appsettings.json", optional: true,reloadOnChange: true);

            builder.AddUserSecrets<MainWindow>();

            configuration = builder.Build();
            string Apikey = configuration.GetSection("Secrets")["OWApiKey"];
            //MessageBox.Show("key : " + Apikey);

        }

        public static string getValue(string key)
        {
            //key possible { "Secret" 
            //                   ==> "OWApiKey" }

            if (configuration == null)
                initConfig();
                
            return configuration.GetSection("Secrets")[key];
        }


    }
}
