using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WorkerService.Controllers;

[ApiController]
[Route("[controller]")]
public class JobController : ControllerBase
{
    private readonly ILogger<JobController> _logger;

    public JobController(ILogger<JobController> logger)
    {
        _logger = logger;
    }

    [HttpPost(Name = "PostJob")]
    public JobResponse Post()
    {
        JobResponse response = new JobResponse
        {
            Date = DateTime.Now
        };

        Console.WriteLine(response.ToString());

        return response;
    }
}
