using Dapr.Client;
using Microsoft.AspNetCore.Mvc;

namespace StateService.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{

    private readonly ILogger<WeatherForecastController> _logger;

    private readonly DaprClient _daprClient;
    const string storeName = "statestore";
    const string key = "LastWeatherForecast";

    public WeatherForecastController(ILogger<WeatherForecastController> logger, DaprClient daprClient)
    {
        _logger = logger;
        _daprClient = daprClient;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public async Task<WeatherForecast> GetAsync()
    {
        return await _daprClient.GetStateAsync<WeatherForecast>(storeName, key);
    }

    [HttpPost(Name = "PostWeatherForecast")]
    public async Task PostAsync(WeatherForecast weatherForecast)
    {
        await _daprClient.SaveStateAsync(storeName, key, weatherForecast);
        return;
    }
}
