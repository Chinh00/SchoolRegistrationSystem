using Dapr;
using Dapr.Client;
using Microsoft.AspNetCore.Mvc;

namespace Enrolment.Api.Controllers;


[ApiController]
[Route("api/[controller]")]
public class EnrolmentController : ControllerBase
{
    private readonly DaprClient _daprClient;

    public EnrolmentController(DaprClient daprClient)
    {
        _daprClient = daprClient;
    }

    [HttpPost("register")]
    public async Task<IActionResult> HandleRegisterCourseAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        await _daprClient.PublishEventAsync("pubsub", "register-course", new {}, cancellationToken);
        
        return Ok("");
    }
}