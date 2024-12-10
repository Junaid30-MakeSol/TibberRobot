using TibberRobot.Domain.Models;

namespace TibberRobot.Application.Interfaces;

public interface ITibberRobotService
{
    Task<ExecutionResult> CalculatePathAsync(RobotRequest request);
    Task<List<ExecutionResult>> GetExecutionResultList();
}

