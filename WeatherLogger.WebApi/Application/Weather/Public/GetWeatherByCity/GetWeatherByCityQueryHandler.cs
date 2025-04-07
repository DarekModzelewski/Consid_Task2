using MediatR;
using Microsoft.EntityFrameworkCore;
using WeatherLogger.WebApi.Infrastructure.Data;

namespace WeatherLogger.WebApi.Application.Weather.Public.GetWeatherData
{
    public class GetWeatherByCityQueryHandler : IRequestHandler<GetWeatherByCityQuery, List<WeatherDto>>
    {
        private readonly WeatherDbContext _context;

        public GetWeatherByCityQueryHandler(WeatherDbContext context)
        {
            _context = context;
        }

        public async Task<List<WeatherDto>> Handle(GetWeatherByCityQuery request, CancellationToken cancellationToken)
        {
            return await _context.WeatherEntries
                .AsNoTracking()
                .Where(x => x.City == request.City)
                .OrderBy(x => x.UpdatedAt)
                .Select(x => new WeatherDto
                {
                    City = x.City,
                    Country = x.Country,
                    Temperature = x.Temperature,
                    UpdatedAt = x.UpdatedAt
                })
                .ToListAsync(cancellationToken);
        }
    }
}
