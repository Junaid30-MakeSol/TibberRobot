using Microsoft.AspNetCore.Mvc;
using TibberRobot.Application.Interfaces;
using TibberRobot.Domain.Models;

namespace TibberRobot.Controllers;

[ApiController]
[Route("tibber-developer-test")]
public class TibberRobotController : ControllerBase
{
    private readonly ITibberRobotService _robotService;

    public TibberRobotController(ITibberRobotService robotService)
    {
        _robotService = robotService;
    }

    [HttpPost("enter-path")]
    public async Task<IActionResult> EnterPath([FromBody] RobotRequest request)
    {
        var result = await _robotService.CalculatePathAsync(request);
        return Ok(result);
    }
}

