using System;
using System.Net.Http;
using System.Threading.Tasks;
using NSubstitute;
using Xunit;
using TDD_Assignment_Abbe.Facade;
using TDD_Assignment_Abbe.Interfaces;
using NSubstitute.ExceptionExtensions;

namespace TDD_Assignment_Abbe.Test
{
    public class WeatherClientFacadeTest
    {
        [Fact]
        public async Task GetWeatherAsync_ReturnsResult_WhenCityIsValid()
        {
            // Arrange
            var mockWeatherClient = Substitute.For<IWeatherClient>();
            mockWeatherClient.GetCurrentWeatherAsync("Stockholm").Returns("Sunny");

            var facade = new WeatherClientFacade(mockWeatherClient);

            // Act
            var result = await facade.GetWeatherAsync("Stockholm");

            // Assert
            Assert.Equal("Sunny", result);
        }

        [Fact]
        public async Task GetWeatherAsync_ThrowsException_WhenClientFails()
        {
            // Arrange
            var mockWeatherClient = Substitute.For<IWeatherClient>();

            // If someone calls GetCurrentWeatherAsync("ErrorCity"), simulate an HTTP error
            mockWeatherClient
                .GetCurrentWeatherAsync("ErrorCity")
                .Throws(new HttpRequestException("Simulated API failure"));

            var facade = new WeatherClientFacade(mockWeatherClient);

            // Act & Assert
            await Assert.ThrowsAsync<HttpRequestException>(
                () => facade.GetWeatherAsync("ErrorCity"));
        }

        [Fact]
        public async Task GetWeatherAsync_ThrowsArgumentException_WhenCityIsNull()
        {
            // Arrange
            var mockWeatherClient = Substitute.For<IWeatherClient>();

            // Manually define what happens if city is null
            mockWeatherClient
                .GetCurrentWeatherAsync(null)
                .Throws(new ArgumentException("City name cannot be null or empty"));

            var facade = new WeatherClientFacade(mockWeatherClient);

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(
                () => facade.GetWeatherAsync(null));
        }
    }
}

