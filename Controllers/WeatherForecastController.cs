using Microsoft.AspNetCore.Mvc;

namespace web_api_rest.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private static List<WeatherForecast> _weatherForecasts = new();

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
        
        if (_weatherForecasts == null || !_weatherForecasts.Any())
        {
            _weatherForecasts = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            }).ToList();
        }
    }

    [HttpGet]
    //[Route("get/weatherforecast")]
    [Route("getweatherforecast")]
    //[Route("[action]")]
    public IEnumerable<WeatherForecast> Get()
    {
        _logger.LogInformation("Getting weather forecasts");
        return _weatherForecasts;
    }

    [HttpPost]
    public IActionResult Post([FromBody] WeatherForecast weatherForecast)
    {
        _weatherForecasts.Add(weatherForecast);
        return Ok();
    }

    [HttpDelete("{index}")]
    public IActionResult Delete(int index)
    {
        _weatherForecasts.RemoveAt(index);
        return Ok();
    }
}
