using MediatR;

namespace WeatherLogger.WebApi.Application.Weather.Internal.GetWeather
{
    public class GetWeatherQuery : IRequest<List<WeatherResult>>
    {
    }
}
