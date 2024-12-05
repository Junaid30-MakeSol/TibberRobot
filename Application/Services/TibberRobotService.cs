using System.Diagnostics;
using TibberRobot.Application.Interfaces;
using TibberRobot.Domain.Models;
using TibberRobot.Infrastructure.Data;

namespace TibberRobot.Application.Services
{
    public class TibberRobotService : ITibberRobotService
    {
        private readonly ApplicationDbContext _dbContext;
        public TibberRobotService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ExecutionResult> CalculatePathAsync(RobotRequest request)
        {
            var stopwatch = Stopwatch.StartNew();

            var visited = new HashSet<(int, int)>();
            var current = (x: request.Start.X, y: request.Start.Y);
            visited.Add(current);

            foreach (var command in request.Commands)
            {
                for (int i = 0; i < command.Steps; i++)
                {
                    current = command.Direction.ToLower() switch
                    {
                        "north" => (current.x, current.y + 1),
                        "east" => (current.x + 1, current.y),
                        "south" => (current.x, current.y - 1),
                        "west" => (current.x - 1, current.y),
                        _ => current
                    };
                    visited.Add(current);
                }
            }

            stopwatch.Stop();

            var result = new ExecutionResult
            {
                Timestamp = DateTime.UtcNow,
                Commands = request.Commands.Count,
                Result = visited.Count,
                Duration = stopwatch.Elapsed.TotalSeconds
            };

            _dbContext.ExecutionRecords.Add(result);
            await _dbContext.SaveChangesAsync();

            return result;
        }

    }
}
