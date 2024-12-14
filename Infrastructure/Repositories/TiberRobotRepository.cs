using Microsoft.EntityFrameworkCore;
using TibberRobot.Domain.Models;
using TibberRobot.Infrastructure.Data;
using TibberRobot.Infrastructure.Interfaces;

namespace TibberRobot.Infrastructure.Repositories;
public class TiberRobotRepository(ApplicationDbContext _applicationDbContext) : ITiberRobotRepository
{
    public async Task<List<ExecutionResult>> GetExecutionResultList() =>
     await _applicationDbContext.Set<ExecutionResult>().ToListAsync();

    public async Task Create(ExecutionResult model)
    {
        await _applicationDbContext.Set<ExecutionResult>().AddAsync(model);
        await _applicationDbContext.SaveChangesAsync();
    }
}

