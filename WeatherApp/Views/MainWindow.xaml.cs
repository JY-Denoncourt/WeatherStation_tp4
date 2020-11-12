using OpenWeatherAPI;
using System.Reflection.Emit;
using System.Windows;
using WeatherApp.Services;
using WeatherApp.ViewModels;

namespace WeatherApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TemperatureViewModel vm;
        OpenWeatherService ows;

        public MainWindow()
        {
            InitializeComponent();

            /// TODO : Faire les appels de configuration ici ainsi que l'initialisation
            ApiHelper.InitializeClient();
            OpenWeatherProcessor.Instance.ApiKey = AppConfiguration.getValue("OWApiKey");
            ows = new OpenWeatherService(AppConfiguration.getValue("OWApiKey"));

            vm = new TemperatureViewModel();
            DataContext = vm;
            vm.SetTemperatureService(ows);
        }


    }
}
