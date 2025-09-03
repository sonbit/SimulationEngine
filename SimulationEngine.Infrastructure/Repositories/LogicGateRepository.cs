using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Repositories;
using SimulationEngine.Infrastructure.DataModel;

namespace SimulationEngine.Infrastructure.Repositories;

public class LogicGateRepository(SimulationEngineDbContext dbContext) : IBaseRepository<LogicGate>
{
    public async Task Create(LogicGate logicGate)
    {
        await dbContext.LogicGates.AddAsync(logicGate);
    }

    public async Task<ICollection<LogicGate>> Read()
    {
        return await dbContext.LogicGates.ToArrayAsync();
    }

    public async Task<LogicGate> Read(int id)
    {
        return await dbContext.LogicGates.FindAsync(id);
    }

    public async Task Update(int id, LogicGate logicGate)
    {
        var existingLogicGate = await Read(id);
        if (existingLogicGate != null)
            dbContext.Entry(existingLogicGate).CurrentValues.SetValues(logicGate);
    }

    public async Task Delete(int id)
    {
        var existingLogicGate = await Read(id);
        if (existingLogicGate != null)
            dbContext.LogicGates.Remove(existingLogicGate);
    }
}