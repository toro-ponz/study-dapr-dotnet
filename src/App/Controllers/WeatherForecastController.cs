using Dapr.Client;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly ILogger<WeatherForecastController> _logger;

    private readonly DaprClient _daprClient;

    const string shareStore = "sharestore";
    const string storeName = "statestore";
    const string key = "LastWeatherForecast";


    public WeatherForecastController(ILogger<WeatherForecastController> logger, DaprClient daprClient)
    {
        _logger = logger;
        _daprClient = daprClient;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public async Task<IEnumerable<WeatherForecast>> GetAsync()
    {
        WeatherForecast forcast = new WeatherForecast
        {
            TemperatureC = 1000,
            Summary = "from App",
            Date = DateTime.Now
        };

        var username = "410e0136-f7d5-437f-a844-e40c0ce40e00";
        await _daprClient.SaveStateAsync(shareStore, username, "from_users_data");

        await _daprClient.SaveStateAsync(storeName, key, forcast);

        WeatherForecast forcastFromApp = await _daprClient.GetStateAsync<WeatherForecast>(storeName, key);

        WeatherForecast forcastFromService = await _daprClient.InvokeMethodAsync<WeatherForecast>(HttpMethod.Get, "state-service", "weatherforecast");

        return new List<WeatherForecast>() { forcastFromApp, forcastFromService };
    }

}
