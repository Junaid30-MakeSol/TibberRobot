using System.Diagnostics;
using TibberRobot.Application.Interfaces;
using TibberRobot.Domain.Models;
using TibberRobot.Infrastructure.Interfaces;

namespace TibberRobot.Application.Services
{
    public class TibberRobotService(ITiberRobotRepository _tiberRobotRepository) : ITibberRobotService
    {
        public async Task<List<ExecutionResult>> GetExecutionResultList() =>
            await _tiberRobotRepository.GetExecutionResultList();

        public async Task<ExecutionResult> CalculatePathAsync(RobotRequest request)
        {
            var stopwatch = Stopwatch.StartNew();

            // Initialize starting position
            int x = request.Start.X;
            int y = request.Start.Y;

            // Process commands
            foreach (var command in request.Commands)
            {
                (x, y) = command.Direction.ToLower() switch
                {
                    "north" => (x, y + command.Steps),
                    "south" => (x, y - command.Steps),
                    "east" => (x + command.Steps, y),
                    "west" => (x - command.Steps, y),
                    _ => throw new ArgumentException($"Invalid direction: {command.Direction}")
                };

            }

            stopwatch.Stop();

            // Calculate result (Manhattan distance from start)
            int result = Math.Abs(x - request.Start.X) + Math.Abs(y - request.Start.Y);

            // Create execution result
            var executionResult = new ExecutionResult
            {
                Timestamp = DateTime.UtcNow,
                Commands = request.Commands.Count,
                Result = result,
                Duration = stopwatch.Elapsed.TotalSeconds
            };

            // Save result asynchronously
            await _tiberRobotRepository.Create(executionResult);
            return executionResult;
        }
    }
}

