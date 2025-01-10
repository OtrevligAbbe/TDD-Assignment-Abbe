using System.Net.Http;
using System.Threading.Tasks;

public class WeatherClient
{
    private readonly HttpClient _httpClient;

    // Initializes the WeatherClient with an HttpClient instance
    public WeatherClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    // Fetches the current weather for the specified city
    public async Task<string> GetCurrentWeatherAsync(string city)
    {
        if (string.IsNullOrWhiteSpace(city))
        {
            throw new ArgumentException("City name cannot be null or empty", nameof(city));
        }

        // Sends a GET request to the weather API
        var response = await _httpClient.GetAsync($"https://api.weather.com/v3/weather/{city}");

        // Throws an exception if the response indicates a failure
        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException("Failed to fetch weather data.");
        }

        // Returns the response content as a string
        return await response.Content.ReadAsStringAsync();
    }
}

