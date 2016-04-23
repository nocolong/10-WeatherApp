using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WeatherApp.Core.Services;
using WeatherApp.Core.Domain;

namespace _10_WeatherApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void buttonGetWeather_Click(object sender, RoutedEventArgs e)
        {
            //calling GetWeatherFor method in WeatherService class, passing the zipcode, and storing
            var result = WeatherService.GetWeatherFor("92123");

            //???Somehow stores the picture into string fileUrl
            string fileUrl = $"{Environment.CurrentDirectory}/{result.icon}.gif";

            //The ! indicates 'does not', as in if data held in fileUrl does not exist.. continue
            if (!File.Exists(fileUrl))
            {
                //Another instance of WebClient*which grabs data from a url*
                //"using" ensures the WebClient method is used only for this code block, then terminates use
                using (var webClient = new WebClient())
                {
                    //
                    byte[] bytes = webClient.DownloadData(result.icon_url);

                    File.WriteAllBytes(fileUrl, bytes);
                }
            }
            //BitmapImage is a class used for loading images using xaml
            BitmapImage image = new BitmapImage(new Uri(fileUrl));

            //
            imageWeather.Source = image;

            //Populates specified info through 'result.'(which comes from GetWeatherFor and zipcode) to textBlocks
            tempBlockf.Text ="Temp. " + result.temp_f.ToString() + " deg f";
            tempBlockc.Text ="Temp. " + result.temp_c.ToString() + " deg c";
            textBlockHumidity.Text = "Humidity " + result.relative_humidity.ToString();
            textBlockElevation.Text ="Elevation " + result.display_location.elevation.ToString();
            textBlockLongitude.Text ="Longitude " + result.display_location.longitude.ToString();
            textBlockLatitude.Text = "Latitude " + result.display_location.latitude.ToString();
            textBlockUV.Text ="UV " + result.UV.ToString();
            textBlockObservationTime.Text ="Observation Time " + result.observation_time.ToString();
            textBlockWeather.Text ="Today's Weather " + result.weather.ToString();


        }
    }
}
