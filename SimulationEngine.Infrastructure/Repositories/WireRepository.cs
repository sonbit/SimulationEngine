using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Repositories;
using SimulationEngine.Infrastructure.DataModel;

namespace SimulationEngine.Infrastructure.Repositories;

public class WireRepository(SimulationEngineDbContext dbContext) : IBaseRepository<Wire>
{
    public async Task Create(Wire wire)
    {
        await dbContext.Wires.AddAsync(wire);
    }

    public async Task<ICollection<Wire>> Read()
    {
        return await dbContext.Wires.ToArrayAsync();
    }

    public async Task<Wire> Read(int id)
    {
        return await dbContext.Wires.FindAsync(id);
    }

    public async Task Update(int id, Wire wire)
    {
        var existingWire = await Read(id);
        if (existingWire != null)
            dbContext.Entry(existingWire).CurrentValues.SetValues(wire);
    }

    public async Task Delete(int id)
    {
        var existingWire = await Read(id);
        if (existingWire != null)
            dbContext.Wires.Remove(existingWire);
    }
}