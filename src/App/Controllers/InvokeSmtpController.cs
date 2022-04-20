using Dapr.Client;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers;

[ApiController]
[Route("[controller]")]
public class InvokeSmtpController : ControllerBase
{
    private readonly ILogger<InvokeSmtpController> _logger;

    private readonly DaprClient _daprClient;

    public InvokeSmtpController(ILogger<InvokeSmtpController> logger, DaprClient daprClient)
    {
        _logger = logger;
        _daprClient = daprClient;
    }

    [HttpGet(Name = "GetInvokeSmtpTrigger")]
    public async void GetAsync()
    {
        var body = "Hello from App via email!";
        var metadata = new Dictionary<string, string>
        {
            ["emailFrom"] = "from@example.com",
            ["emailTo"] = "user@example.net",
            ["subject"] = "Hello from App via email!"
        };

        await _daprClient.InvokeBindingAsync("smtp", "create", body, metadata);

        Console.WriteLine("Binding sent.");
    }
}
