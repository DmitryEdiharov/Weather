using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
using Component1;

namespace Weather
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            try
            {
                wc = new WeatherChecker();
                wc.InitializeArrays();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            InitializeComponent();
            foreach (var item in wc.GetCities())
            {
                searchBox.Items.Add(item.name);
            }
        }

        WeatherChecker wc;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (searchBox.SelectedItem != null)
            {
                try
                {
                    wc.id = wc.GetCityIdByName(searchBox.Text);
                    wc.GetWeatherByCityId();
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show(ex.Message);
                }

                dateTextBox.Text = wc.Today.day + "." + wc.Today.month + "." + wc.Today.year + " на " + wc.Today.hour + ":00";
                cloudTextBox.Text = wc.Today.cloudiness;
                precipitationTextBox.Text = wc.Today.precipitation;
                pressureTextBox.Text = "Мин: " + wc.Today.pressure_min + " Макс: " + wc.Today.pressure_max;
                temperatureTextBox.Text = "Мин: " + wc.Today.temperature_min + " Макс: " + wc.Today.temperature_max;
                windTextBox.Text = "Мин: " + wc.Today.wind_min + " Макс: " + wc.Today.wind_max;
                wind_directionTextBox.Text = wc.Today.wind_dir;
                relwetTextBox.Text = "Мин: " + wc.Today.relwet_min + " Макс: " + wc.Today.relwet_max;
                heatTextBox.Text = "Мин: " + wc.Today.heat_min + " Макс: " + wc.Today.heat_max;

                tomorrow_dateTextBox.Text = wc.Tomorrow.day + "." + wc.Tomorrow.month + "." + wc.Tomorrow.year + " на " + wc.Tomorrow.hour + ":00";
                tomorrow_cloudTextBox.Text = wc.Tomorrow.cloudiness;
                tomorrow_precipitationTextBox.Text = wc.Tomorrow.precipitation;
                tomorrow_pressureTextBox.Text = "Мин: " + wc.Tomorrow.pressure_min + " Макс: " + wc.Tomorrow.pressure_max;
                tomorrow_temperatureTextBox.Text = "Мин: " + wc.Tomorrow.temperature_min + " Макс: " + wc.Tomorrow.temperature_max;
                tomorrow_windTextBox.Text = "Мин: " + wc.Tomorrow.wind_min + " Макс: " + wc.Tomorrow.wind_max;
                tomorrow_wind_directionTextBox.Text = wc.Tomorrow.wind_dir;
                tomorrow_relwetTextBox.Text = "Мин: " + wc.Tomorrow.relwet_min + " Макс: " + wc.Tomorrow.relwet_max;
                tomorrow_heatTextBox.Text = "Мин: " + wc.Tomorrow.heat_min + " Макс: " + wc.Tomorrow.heat_max;


            }
        }
    }
}
