using Microsoft.EntityFrameworkCore;
using TibberRobot.Domain.Models;
using TibberRobot.Infrastructure.Data;
using TibberRobot.Infrastructure.Interfaces;

namespace TibberRobot.Infrastructure.Repositories;
public class TiberRobotRepository : ITiberRobotRepository
{
    private readonly ApplicationDbContext _applicationDbContext;
    public TiberRobotRepository(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<List<ExecutionResult>> GetExecutionResultList() =>
     await _applicationDbContext.Set<ExecutionResult>().ToListAsync();

    public async Task Create(ExecutionResult model)
    {
        await _applicationDbContext.Set<ExecutionResult>().AddAsync(model);
        await _applicationDbContext.SaveChangesAsync();
    }

}

