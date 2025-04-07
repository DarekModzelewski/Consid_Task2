using MediatR;
using Microsoft.AspNetCore.Mvc;
using WeatherLogger.WebApi.Application.Weather.Public.GetWeatherData;

namespace WeatherLogger.WebApi.Controllers;

[ApiController]
[Route("api/weather")]
public class WeatherController : ControllerBase
{
    private readonly IMediator _mediator;

    public WeatherController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{city}")]
    public async Task<IActionResult> GetCityWeather(string city, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetWeatherByCityQuery { City = city }, cancellationToken);

        return Ok(result);
    }
}
