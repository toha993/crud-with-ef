using Microsoft.AspNetCore.Mvc;
using Url_Shortener.UrlShortener.Core.Models;

namespace Url_Shortener.UrlShortener.Web.Controllers;

[ApiController]
[Route("")]
public class ShortenerRequestController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<ShortenerRequestController> _logger;

    public ShortenerRequestController(ILogger<ShortenerRequestController> logger)
    {
        _logger = logger;
    }

    [HttpGet("GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
    }
}