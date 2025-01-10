using TDD_Assignment_Abbe.Classes;
using TDD_Assignment_Abbe.Facade;
using NSubstitute;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using System.Net;

namespace TDD_Assignment_Abbe.Test
{
    public class WeatherClientTests
    {
        [Fact]
        public async Task GetCurrentWeatherAsync_ReturnsCorrectData()
        {
            // Arrange
            var mockHandler = new MockHttpMessageHandler(request =>
            {
                return new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent("{\"weather\": \"Sunny\"}")
                };
            });

            var client = new HttpClient(mockHandler)
            {
                BaseAddress = new Uri("https://api.weather.com")
            };

            var weatherClient = new WeatherClient(client);

            // Act
            var result = await weatherClient.GetCurrentWeatherAsync("Stockholm");

            // Assert
            Assert.Contains("Sunny", result);
        }



        [Fact]
        public async Task GetCurrentWeatherAsync_ThrowsHttpRequestException_OnInvalidResponse()
        {
            // Arrange
            var mockHandler = new MockHttpMessageHandler(request =>
            {
                return new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.BadRequest
                };
            });

            var client = new HttpClient(mockHandler)
            {
                BaseAddress = new Uri("https://api.weather.com")
            };

            var weatherClient = new WeatherClient(client);

            // Act & Assert
            await Assert.ThrowsAsync<HttpRequestException>(() => weatherClient.GetCurrentWeatherAsync("InvalidCity"));
        }



    }
}
