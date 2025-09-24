using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using SimulationEngine.Domain.Compilers;
using SimulationEngine.Domain.Compilers.Models;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Repositories;
using SimulationEngine.Infrastructure.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimulationEngine.Infrastructure.Repositories;

public partial class SubCircuitRepository(SimulationEngineDbContext dbContext, ITruthTableRepository truthTableRepository) : ISubCircuitRepository
{
    private readonly SimulationEngineDbContext _dbContext = dbContext;

    public async Task<SubCircuit> CreateOrGetAsync(SubCircuit subCircuit)
    {
        var subCircuitClosure = SubCircuitCompiler.Compile(subCircuit);
        var hash = subCircuitClosure.SubCircuitPlaced.SubCircuit.Hash;
        await EnsurePersistedAsync(hash, subCircuitClosure);
        return await _dbContext.SubCircuits.AsNoTracking().FirstAsync(subCircuit => subCircuit.Hash == hash);
    }

    public async Task<List<SubCircuit>> GetAllAsync() => await GetSubCircuitQuery().ToListAsync();

    public async Task<SubCircuit> GetByIdAsync(int id)
    {
        var (template, subCircuitPlacements) = await GetSubCircuitWithChildren(id);
        if (template == null && subCircuitPlacements == null)
            return null;

        var subCircuit = await BuildInstanceFromTemplateAsync(template, subCircuitPlacements);
        return subCircuit;
    }

    public async Task<SubCircuit> GetByTitleAsync(string title) => 
        await GetSubCircuitQuery().FirstOrDefaultAsync(subCircuit => subCircuit.Title == title);

    private async Task EnsurePersistedAsync(string hash, SubCircuitClosure subCircuitClosure)
    {
        if (await _dbContext.SubCircuits.AsNoTracking().AnyAsync(s => s.Hash == hash)) return;

        var placed = subCircuitClosure.MapByHash[hash];
        foreach (var childHash in placed.SubCircuitPlacementInfos.Select(p => p.ChildSubCircuitHash).Distinct(StringComparer.Ordinal))
            await EnsurePersistedAsync(childHash, subCircuitClosure);

        await PersistPlacedAsync(placed);
    }

    private IIncludableQueryable<SubCircuit, Terminal> GetSubCircuitQuery()
    {
        return _dbContext.SubCircuits
            .AsNoTrackingWithIdentityResolution()
            .AsSplitQuery()
            .Include(subCircuit => subCircuit.Ports)
                .ThenInclude(port => port.PortMetadata)
            .Include(subCircuit => subCircuit.LogicGates)
                .ThenInclude(logicGate => logicGate.LogicGateMetadata)
            .Include(subCircuit => subCircuit.LogicGates)
                .ThenInclude(logicGate => logicGate.Pins)
            .Include(subCircuit => subCircuit.LogicGates)
                .ThenInclude(logicGate => logicGate.TruthTable)
            .Include(subCircuit => subCircuit.Wires)
                .ThenInclude(wire => wire.StartTerminal)
            .Include(subCircuit => subCircuit.Wires)
                .ThenInclude(wire => wire.EndTerminal);
    }
}