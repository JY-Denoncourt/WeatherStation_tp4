using Microsoft.Extensions.Configuration;

namespace WeatherApp
{
    static class AppConfiguration
    {
        static IConfiguration configuration;

        static void initConfig()
        {
            var builder = new ConfigurationBuilder();
            builder.AddJsonFile("appsettings.json",
                optional: true,
                reloadOnChange: true);

            builder.AddUserSecrets<MainWindow>();

            configuration = builder.Build();
        }

        static string getValue(string key)
        {
            //key possible { "Secret" 
            //                   ==> "OWApiKey" }

            if (configuration == null)
                initConfig();
                
            return configuration.GetSection("Secrets")[key];
        }


    }
}
