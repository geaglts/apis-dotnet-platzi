using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace first_api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly ILogger<WeatherForecastController> _logger;
    private static List<WeatherForecast> ListWeatherForecast = new List<WeatherForecast>();

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
        if (ListWeatherForecast == null || !ListWeatherForecast.Any())
        {
            ListWeatherForecast = new List<WeatherForecast>() { };
        }
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return ListWeatherForecast;
    }

    [HttpPost]
    public IActionResult Post(WeatherForecast weatherForecast)
    {
        weatherForecast.Date = DateTime.Now.ToString(new CultureInfo("es-MX"));
        ListWeatherForecast.Add(weatherForecast);
        return Ok(weatherForecast);
    }

    [HttpDelete("{index}")]
    public IActionResult Delete(int index)
    {
        if (ListWeatherForecast[index] == null)
        {
            return BadRequest(new { message = "Sorry but we can't found that WeatherForecast" });
        }

        ListWeatherForecast.RemoveAt(index);

        return Ok(new { message = "Removed Successfully" });
    }
}
