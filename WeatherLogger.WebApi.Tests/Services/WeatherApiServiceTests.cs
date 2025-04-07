using System.Net.Http;
using Microsoft.Extensions.Configuration;
using Shouldly;
using WeatherLogger.WebApi.Application.Contracts;
using WeatherLogger.WebApi.Infrastructure.Services;
using Xunit;

namespace WeatherLogger.WebApi.Tests.Services
{
    public class WeatherApiServiceTests
    {
        private readonly IWeatherApiService _service;

        public WeatherApiServiceTests()
        {
            var httpClient = new HttpClient();

            var config = new ConfigurationBuilder()
                .AddInMemoryCollection(new Dictionary<string, string>
                {
                    { "OpenWeatherApiKey", "YOUR_REAL_API_KEY" } 
                })
                .Build();

            _service = new WeatherApiService(httpClient, config);
        }

        [Fact]
        public async Task Should_Fetch_Weather_Response_For_London()
        {
            // Arrange
            var city = "London";

            // Act
            var result = await _service.GetWeatherForCityAsync(city);

            // Assert
            result.ShouldNotBeNull();
        }

        [Fact]
        public async Task Should_Return_Correct_Weather_Data_For_London()
        {
            // Arrange
            var city = "London";

            // Act
            var result = await _service.GetWeatherForCityAsync(city);

            // Assert
            result.ShouldNotBeNull();
            result.City.ShouldBe("London", StringCompareShould.IgnoreCase);
            result.Country.ShouldNotBeNullOrEmpty();
            result.Temperature.ShouldBeInRange(-100, 100); // sanity check
        }
    }
}
