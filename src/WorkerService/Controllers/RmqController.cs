using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WorkerService.Controllers;

[ApiController]
[Route("[controller]")]
public class RmqController : ControllerBase
{
    private readonly ILogger<RmqController> _logger;

    public RmqController(ILogger<RmqController> logger)
    {
        _logger = logger;
    }

    [HttpPost(Name = "PostRmqQueue")]
    public void Post(RmqRequest request)
    {
        Console.WriteLine((string)request.Message);

        return;
    }
}
