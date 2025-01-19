using System;
using System.Net.Http;
using System.Threading.Tasks;
using TDD_Assignment_Abbe.Interfaces;

namespace TDD_Assignment_Abbe.Classes
{
    /// Real implementation that fetches weather data using HttpClient.
    public class WeatherClient : IWeatherClient
    {
        private readonly HttpClient _httpClient;

        public WeatherClient(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<string> GetCurrentWeatherAsync(string city)
        {
            if (string.IsNullOrWhiteSpace(city))
                throw new ArgumentException("City name cannot be null or empty.", nameof(city));

            // For example: if BaseAddress = "https://api.mockweather.com", 
            // this request becomes GET https://api.mockweather.com/weather/{city}
            var response = await _httpClient.GetAsync($"/weather/{city}");
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException(
                    $"Could not fetch weather for '{city}'. Status: {response.StatusCode}");
            }

            return await response.Content.ReadAsStringAsync();
        }
    }
}



