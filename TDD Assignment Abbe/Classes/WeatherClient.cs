using System.Net.Http;
using System.Threading.Tasks;

public class WeatherClient
{
    private readonly HttpClient _httpClient;

    public WeatherClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<string> GetCurrentWeatherAsync(string city)
    {
        if (string.IsNullOrWhiteSpace(city))
        {
            throw new ArgumentException("City name cannot be null or empty", nameof(city));
        }

        var response = await _httpClient.GetAsync($"https://api.weather.com/v3/weather/{city}");

        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException("Failed to fetch weather data.");
        }

        return await response.Content.ReadAsStringAsync();
    }
}
