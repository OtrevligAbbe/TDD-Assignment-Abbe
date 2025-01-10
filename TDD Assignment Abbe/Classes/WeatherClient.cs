using System.Net.Http;
using System.Threading.Tasks;

public class WeatherClient
{
    private readonly HttpClient _httpClient;

    public WeatherClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    // Hämta väderinformation från API:t (mockas i testerna)
    public async Task<string> GetCurrentWeatherAsync(string city)
    {
        // Mockad URL för API
        string url = $"https://api.weather.com/v1/city/{city}/weather";
        HttpResponseMessage response = await _httpClient.GetAsync(url);

        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException("Failed to fetch weather data.");
        }

        return await response.Content.ReadAsStringAsync();
    }
}
