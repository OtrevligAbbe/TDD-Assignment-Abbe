using System.Threading.Tasks;
using TDD_Assignment_Abbe.Interfaces;

namespace TDD_Assignment_Abbe.Facade
{
    /// A facade that wraps IWeatherClient and provides a simpler entry point.
    public class WeatherClientFacade
    {
        private readonly IWeatherClient _weatherClient;

        public WeatherClientFacade(IWeatherClient weatherClient)
        {
            _weatherClient = weatherClient;
        }

        /// Fetches weather data for a given city, returning raw data as a string.
        public async Task<string> GetWeatherAsync(string city)
        {
            // Simply delegates to the underlying WeatherClient
            return await _weatherClient.GetCurrentWeatherAsync(city);
        }
    }
}

