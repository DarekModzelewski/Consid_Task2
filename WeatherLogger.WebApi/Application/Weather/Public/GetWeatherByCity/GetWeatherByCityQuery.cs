using MediatR;

namespace WeatherLogger.WebApi.Application.Weather.Public.GetWeatherData
{
    public class GetWeatherByCityQuery : IRequest<List<WeatherDto>>
    {
        public string City { get; set; }
    }
}
