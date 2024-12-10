using TibberRobot.Domain.Models;

namespace TibberRobot.Infrastructure.Interfaces;
public interface ITiberRobotRepository
{
    Task<List<ExecutionResult>> GetExecutionResultList();
    Task Create(ExecutionResult model);
}

