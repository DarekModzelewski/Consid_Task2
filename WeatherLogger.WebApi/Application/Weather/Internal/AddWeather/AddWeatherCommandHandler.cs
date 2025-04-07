using MediatR;
using WeatherLogger.WebApi.Domain.Weather;
using WeatherLogger.WebApi.Infrastructure.Data;

namespace WeatherLogger.WebApi.Application.Weather.Internal.AddWeather
{
    internal class AddWeatherCommandHandler : IRequestHandler<AddWeatherCommand,Unit>
    {
        private readonly WeatherDbContext _context;

        public AddWeatherCommandHandler(WeatherDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(AddWeatherCommand request, CancellationToken cancellationToken)
        {
            var weatherEntry = WeatherEntry.Create(
                request.City,
                request.Country,
                request.Temperature,
                request.UpdatedAt);

            _context.WeatherEntries.Add(weatherEntry);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
