using Microsoft.AspNetCore.Mvc;
using TodoApi.BLL;

namespace TodoApi.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
	private static readonly string[] Summaries = new[]
	{
		"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
	};

	private readonly ILogger<WeatherForecastController> _logger;
	private readonly IInterestManager _interestManager;

	public WeatherForecastController(ILogger<WeatherForecastController> logger, IInterestManager interestManager)
	{
		_logger = logger;
		_interestManager = interestManager;
	}

	[HttpGet(Name = "GetWeatherForecast")]
	public IEnumerable<WeatherForecast> Get()
	{
		return Enumerable.Range(1, 5).Select(index => new WeatherForecast
		{
			Date = DateTime.Now.AddDays(index),
			TemperatureC = Random.Shared.Next(-20, 55),
			Summary = Summaries[Random.Shared.Next(Summaries.Length)]
		})
		.ToArray();
	}

	[HttpPost(Name = "GetCompoundInterest")]
	public double Post(int principal, double interestRate, int period)
	{
		return _interestManager.CalculateInterest(principal, interestRate, period);
	}
}
