using OpenWeatherAPI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Models;
using WeatherApp.ViewModels;

namespace WeatherApp.Services
{
    public class OpenWeatherService : ITemperatureService
    {
        private static OpenWeatherProcessor owp;

        public TemperatureModel LastTemp; 


        public OpenWeatherService(string apiKey)
        {
            owp = OpenWeatherProcessor.Instance;
            owp.ApiKey = apiKey;

            LastTemp = new TemperatureModel();
        }


        public async Task<TemperatureModel> GetTempAsync()
        {
            var weather = await owp.GetCurrentWeatherAsync();

            //SRC = https://stackoverflow.com/questions/4964634/how-to-convert-long-type-datetime-to-datetime-with-correct-time-zone
            long unixDate = weather.DateTime;
            DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            LastTemp.DateTime = start.AddSeconds(unixDate).ToLocalTime();

            /*DateTime dt = new DateTime(weather.DateTime);
            LastTemp.DateTime = dt;*/
            LastTemp.Temperature = weather.Main.Temperature;
           

            return LastTemp;
        }

    }
}
