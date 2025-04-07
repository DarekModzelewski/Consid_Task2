using MediatR;
using WeatherLogger.WebApi.Application.Weather.Internal.AddWeather;
using WeatherLogger.WebApi.Application.Weather.Internal.GetWeather;

namespace WeatherLogger.WebApi.Infrastructure.Workers
{
    public class FetchWeatherJob : BackgroundService
    {
        private readonly ILogger<FetchWeatherJob> _logger;
        private readonly IServiceProvider _serviceProvider;


        public FetchWeatherJob(
            ILogger<FetchWeatherJob> logger,
            IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;

        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("🚀 FetchWeatherJob started.");

            while (!stoppingToken.IsCancellationRequested)
            {
                using var scope = _serviceProvider.CreateScope();
                var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();

                try
                {
                    var weatherResults = await mediator.Send(new GetWeatherQuery(), stoppingToken);

                    if (weatherResults.Any())
                    {
                        foreach (var result in weatherResults)
                        {
                            var command = new AddWeatherCommand
                            {
                                City = result.City,
                                Country = result.Country,
                                Temperature = result.Temperature,
                                UpdatedAt = DateTime.UtcNow
                            };

                            await mediator.Send(command, stoppingToken);

                            _logger.LogInformation($"[OK] {result.City}, {result.Country}, {result.Temperature}°C");
                        }
                    }
                    else
                    {
                        _logger.LogWarning("[SKIP] No weather data received.");
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "❌ Error while processing weather data.");
                }

                await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
            }
        }

    }
}
