using Dapr;
using Dapr.Client;
using Microsoft.AspNetCore.Mvc;

namespace Course.Api.Controllers;


[ApiController]
[Route("api/[controller]")]

public class CourseController : ControllerBase
{

    private readonly ILogger<CourseController> _logger;

    public CourseController(ILogger<CourseController> logger)
    {
        _logger = logger;
    }

    [Topic("pubsub", "register-course")]
    [HttpPost("reciver")]
    public async Task<IActionResult> HandleRegisterCourseAsync()
    {
        
        _logger.LogInformation("Reciver message ");
        return Ok();

    }
}