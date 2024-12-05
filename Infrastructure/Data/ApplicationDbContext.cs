using Microsoft.EntityFrameworkCore;
using TibberRobot.Domain.Models;
using TibberRobot.Infrastructure.Common.Interfaces;

namespace TibberRobot.Infrastructure.Data;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<ExecutionResult> ExecutionRecords => Set<ExecutionResult>();
}