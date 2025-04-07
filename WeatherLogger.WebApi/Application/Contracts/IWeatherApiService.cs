using WeatherLogger.WebApi.Application.Weather.Internal.GetWeather;

namespace WeatherLogger.WebApi.Application.Contracts
{
    public interface IWeatherApiService
    {
        Task<WeatherResult?> GetWeatherForCityAsync(string city);
    }
}
