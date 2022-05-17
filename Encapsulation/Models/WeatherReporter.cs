using System;
namespace Encapsulation.Models
{
    public class WeatherReporter
    {
        private readonly string _location;
        private readonly int    _temperature_centigrade;
        private double          _temperature_fahrenheit;
        private const int       _OFFSET_FOR_FAHRENHEIT = 32;
        private const double    _CONVERSION_FACTOR_FOR_FAHRENHEIT = 9.0 / 5.0;
        private const int       _MAXIMUM_TEMPERATURE_CENTIGRADE = 30;
        private const int       _MINIMUM_TEMPERATURE_CENTIGRADE = 10;
        private const int       _HIGHEST_TEMPERATURE_ON_EARTH_CENTIGARDE = 94;
        private const int       _LOWEST_TEMPERATURE_ON_EARTH_CENTIGRADE = -89;

        public WeatherReporter(string location, int temperature)
        {
            // some basic error checking/validation ...

            if (location == " " || location == "")
            {
                Console.WriteLine("ERROR: Input Location Invalid");
                _location = "Invalid Location Name"; // compiler says it mustn't be null on exit!
                return;
            }

            if (temperature < _LOWEST_TEMPERATURE_ON_EARTH_CENTIGRADE || temperature > _HIGHEST_TEMPERATURE_ON_EARTH_CENTIGARDE)
            {
                Console.WriteLine("ERROR: Input Temperature Out of Range,(though it might be a record!)");
                _location = "Invalid Location Name"; // compiler says it mustn't be null on exit!
                return;
            }
  
            _location = location;
            _temperature_centigrade = temperature;
        }

        private double ConvertCentigradeToFahrenheit()
        {
            _temperature_fahrenheit = (_CONVERSION_FACTOR_FOR_FAHRENHEIT * _temperature_centigrade) + _OFFSET_FOR_FAHRENHEIT;
            return (int) _temperature_fahrenheit;
        }

        public string GetFormattedStringForConsolePrint()
        {
            return $"I am in {_location} and it is {CurrentLocation()}. {CurrentTemperature()}! The temperature in Fahrenheit is {ConvertCentigradeToFahrenheit()}F.";
        }

        private string CurrentLocation()
        {
            if (_location == "London") return "cloudy";

            if (_location == "California") return "bright";

            if (_location == "Cape Town") return "sunny";

            return "ERROR: No valid weather report returned";
        }

        private string CurrentTemperature()
        {
            if (_temperature_centigrade > _MAXIMUM_TEMPERATURE_CENTIGRADE) return "It's too hot :( ";
            
            if (_temperature_centigrade < _MINIMUM_TEMPERATURE_CENTIGRADE) return "It's too cold :( ";
          
            return "Ahhh...it's just right :) ";
        }
    }
}

