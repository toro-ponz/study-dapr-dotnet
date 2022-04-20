using Dapr.Client;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers;

[ApiController]
[Route("[controller]")]
public class InvokeTriggerController : ControllerBase
{
    private readonly ILogger<InvokeTriggerController> _logger;

    private readonly DaprClient _daprClient;

    public InvokeTriggerController(ILogger<InvokeTriggerController> logger, DaprClient daprClient)
    {
        _logger = logger;
        _daprClient = daprClient;
    }

    [HttpGet(Name = "GetInvokeTrigger")]
    public async void GetAsync()
    {
        var payloadData = new
        {
            message = "from App to Worker via dapr component with RabbitMQ",
        };

        await _daprClient.InvokeBindingAsync("Rmq", "create", payloadData);

        Console.WriteLine("Binding sent.");
    }
}
