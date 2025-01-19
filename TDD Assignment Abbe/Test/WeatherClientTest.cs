using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using TDD_Assignment_Abbe.Classes;
using TDD_Assignment_Abbe.Interfaces;
using TDD_Assignment_Abbe.Test.TestHelpers;

namespace TDD_Assignment_Abbe.Test
{
    public class WeatherClientTest
    {
        [Fact]
        public async Task GetCurrentWeatherAsync_ReturnsSunny_WhenApiReturnsOk()
        {
            // Arrange
            var mockHandler = new MockHttpMessageHandler((request) =>
            {
                // We simulate a 200 OK with "Sunny" content
                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent("Sunny")
                };
            });

            var httpClient = new HttpClient(mockHandler)
            {
                BaseAddress = new Uri("https://api.mockweather.com")
            };

            IWeatherClient client = new WeatherClient(httpClient);

            // Act
            var result = await client.GetCurrentWeatherAsync("Stockholm");

            // Assert
            Assert.Equal("Sunny", result);
        }

        [Fact]
        public async Task GetCurrentWeatherAsync_ThrowsArgumentException_WhenCityIsNullOrWhitespace()
        {
            // Arrange
            var mockHandler = new MockHttpMessageHandler(_ =>
                new HttpResponseMessage(HttpStatusCode.OK));
            var httpClient = new HttpClient(mockHandler);

            IWeatherClient client = new WeatherClient(httpClient);

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() => client.GetCurrentWeatherAsync(null));
            await Assert.ThrowsAsync<ArgumentException>(() => client.GetCurrentWeatherAsync(""));
        }

        [Fact]
        public async Task GetCurrentWeatherAsync_ThrowsHttpRequestException_WhenApiReturnsError()
        {
            // Arrange
            var mockHandler = new MockHttpMessageHandler((request) =>
            {
                // Simulate a 400 Bad Request
                return new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent("Bad Request")
                };
            });

            var httpClient = new HttpClient(mockHandler)
            {
                BaseAddress = new Uri("https://api.mockweather.com")
            };

            IWeatherClient client = new WeatherClient(httpClient);

            // Act & Assert
            await Assert.ThrowsAsync<HttpRequestException>(() => client.GetCurrentWeatherAsync("FailingCity"));
        }
    }
}

