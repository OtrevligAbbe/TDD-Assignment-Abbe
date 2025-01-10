using TDD_Assignment_Abbe.Classes;

namespace TDD_Assignment_Abbe.Facade
{
    public class WeatherServiceFacade
    {
        private readonly WeatherClient _weatherClient;

        // Initializes the facade with a WeatherClient instance
        public WeatherServiceFacade(WeatherClient weatherClient)
        {
            _weatherClient = weatherClient;
        }

        // Retrieves the current weather for the specified city
        public string GetWeather(string city)
        {
            var weatherTask = _weatherClient.GetCurrentWeatherAsync(city);
            weatherTask.Wait(); // Blocks execution until the task is completed
            return weatherTask.Result;
        }
    }
}
