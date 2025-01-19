using System.Threading.Tasks;

namespace TDD_Assignment_Abbe.Interfaces
{
    /// Defines the contract for fetching weather data.
    /// This allows us to mock an implementation with NSubstitute.
    public interface IWeatherClient
    {
        Task<string> GetCurrentWeatherAsync(string city);
    }
}
