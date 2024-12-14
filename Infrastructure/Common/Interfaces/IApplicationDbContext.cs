using Microsoft.EntityFrameworkCore;
using TibberRobot.Domain.Models;

namespace TibberRobot.Infrastructure.Common.Interfaces;
public interface IApplicationDbContext
{
    DbSet<ExecutionResult> ExecutionRecords { get; }

}

