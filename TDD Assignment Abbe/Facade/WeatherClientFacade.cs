using TDD_Assignment_Abbe.Classes;

namespace TDD_Assignment_Abbe.Facade
{
    public class WeatherServiceFacade
    {
        private readonly WeatherClient _weatherClient;

        public WeatherServiceFacade(WeatherClient weatherClient)
        {
            _weatherClient = weatherClient;
        }

        public string GetWeather(string city)
        {
            var weatherTask = _weatherClient.GetCurrentWeatherAsync(city);
            weatherTask.Wait(); // Blockerar till resultatet är klart
            return weatherTask.Result;
        }
    }
}