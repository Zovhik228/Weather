using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Weather.Classes
{
    public class WeatherViewModel : INotifyPropertyChanged
    {
        private ForecastData _forecastData;
        private readonly Weather _weatherService;

        public WeatherViewModel() => _weatherService = new Weather();

        public ForecastData ForecastData
        {
            get => _forecastData;
            set
            {
                _forecastData = value;
                OnPropertyChanged();
            }
        }

        public async Task LoadWeatherAsync(string city) => ForecastData = await _weatherService.GetWeatherForecastAsync(city);

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}