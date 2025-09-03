using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Repositories;
using SimulationEngine.Infrastructure.DataModel;

namespace SimulationEngine.Infrastructure.Repositories;

public class SubCircuitRepository(SimulationEngineDbContext dbContext) : IBaseRepository<SubCircuit>
{
    public async Task Create(SubCircuit subCircuit)
    {
        await dbContext.SubCircuits.AddAsync(subCircuit);
    }

    public async Task<ICollection<SubCircuit>> Read()
    {
        return await dbContext.SubCircuits
            .Include(subCircuit => subCircuit.Ports)
            .Include(subCircuit => subCircuit.LogicGates)
                .ThenInclude(logicGate => logicGate.TruthTable)
            .Include(subCircuit => subCircuit.Ports)
            .Include(subCircuit => subCircuit.Wires)
                .ThenInclude(wire => wire.StartTerminal)
            .Include(subCircuit => subCircuit.Wires)
                .ThenInclude(wire => wire.EndTerminal)
            .ToArrayAsync();
    }

    public async Task<SubCircuit> Read(int id)
    {
        return await dbContext.SubCircuits.FindAsync(id);
    }

    public async Task Update(int id, SubCircuit subCircuit)
    {
        var existingSubCircuit = await Read(id);
        if (existingSubCircuit != null)
            dbContext.Entry(existingSubCircuit).CurrentValues.SetValues(subCircuit);
    }

    public async Task Delete(int id)
    {
        var existingSubCircuit = await Read(id);
        if (existingSubCircuit != null)
            dbContext.SubCircuits.Remove(existingSubCircuit);
    }
}