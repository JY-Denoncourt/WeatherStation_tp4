using OpenWeatherAPI;
using System;
using System.Threading.Tasks;
using System.Windows;
using WeatherApp.Commands;
using WeatherApp.Models;

namespace WeatherApp.ViewModels
{
    public class TemperatureViewModel : BaseViewModel
    {
        #region Variables
        private TemperatureModel currentTemp;

        #endregion


        #region GETTER - SETTER
        public ITemperatureService TemperatureService { get; private set; }

        public DelegateCommand<string> GetTempCommand { get; set; }

        public TemperatureModel CurrentTemp 
        { 
            get => currentTemp;
            set
            {
                currentTemp = value;
                OnPropertyChanged();
                OnPropertyChanged("RawText");
            }
        }


        public string RawText {
            get {
                if (CurrentTemp != null)
                    return $"Time : {CurrentTemp.DateTime.ToLocalTime()} {Environment.NewLine}Temperature : {CurrentTemp.Temperature}";
                else
                    return string.Empty;
            }
        }
        #endregion


        #region Constructors
        public TemperatureViewModel()
        {
            GetTempCommand = new DelegateCommand<string>(GetTemp, CanGetTemp);
            
        }

        #endregion


        #region Methodes Commande
        public bool CanGetTemp(string obj)
        {
            return TemperatureService != null;
        }

        public void GetTemp(string obj)
        {
            if (TemperatureService == null) throw new NullReferenceException();

            _ = GetTempAsync();

        }

        private async Task GetTempAsync()
        {
            CurrentTemp = await TemperatureService.GetTempAsync();
        }

        #endregion


        #region Methode utilitaire
        public void SetTemperatureService(ITemperatureService srv)
        {
            TemperatureService = srv;
        }
        #endregion
    }
}
