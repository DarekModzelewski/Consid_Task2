using MediatR;
using Microsoft.Extensions.Options;
using WeatherLogger.WebApi.Application.Configuration;
using WeatherLogger.WebApi.Application.Contracts;

namespace WeatherLogger.WebApi.Application.Weather.Internal.GetWeather
{
    internal class GetWeatherQueryHandler : IRequestHandler<GetWeatherQuery, List<WeatherResult>>
    {
        private readonly IWeatherApiService _weatherApiService;
        private readonly WeatherSettings _settings;

        public GetWeatherQueryHandler(IWeatherApiService weatherApiService, IOptions<WeatherSettings> options)
        {
            _weatherApiService = weatherApiService;
            _settings = options.Value;
        }

        public async Task<List<WeatherResult>> Handle(GetWeatherQuery request, CancellationToken cancellationToken)
        {
            var results = new List<WeatherResult>();

            foreach (var loc in _settings.Locations)
            {
                var result = await _weatherApiService.GetWeatherForCityAsync(loc.City);

                if (result != null)
                    results.Add(result);
            }

            return results;
        }
    }
}
