using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using TibberRobot.Application.Interfaces;
using TibberRobot.Domain.Models;

namespace TibberRobot.Controllers;

[Produces("application/json")]
[ApiController]
[EnableCors("LocalPolicy")]
[Route("tibber-robot")]
public class TibberRobotController(ITibberRobotService _robotService) : ControllerBase
{
    [HttpGet("list")]
    [ProducesResponseType(typeof(ExecutionResult), statusCode: 200)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<List<ExecutionResult>> GetExecutionResultList() =>
      await _robotService.GetExecutionResultList();

    [HttpPost("enter-path")]
    [ProducesResponseType(typeof(ExecutionResult), statusCode: 200)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<ExecutionResult>> EnterPath([FromBody] RobotRequest request)
    {
        var result = await _robotService.CalculatePathAsync(request);
        return Ok(result);
    }
}

