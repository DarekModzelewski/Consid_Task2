using MediatR;

namespace WeatherLogger.WebApi.Application.Weather.Internal.AddWeather
{
    public class AddWeatherCommand : IRequest<Unit>
    {
        public string City { get; set; }
        public string Country { get; set; }
        public float Temperature { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
