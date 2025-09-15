using Microsoft.EntityFrameworkCore;
using SimulationEngine.Domain.Comparers;
using SimulationEngine.Domain.Extensions;
using SimulationEngine.Domain.Hashers;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Repositories;
using SimulationEngine.Infrastructure.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SimulationEngine.Infrastructure.Repositories;

public class SubCircuitRepository(
    SimulationEngineDbContext dbContext,
    ITruthTableRepository truthTableRepository) : BaseRepository<SubCircuit>(dbContext), ISubCircuitRepository
{
    private readonly SimulationEngineDbContext _dbContext = dbContext;

    public override async Task<SubCircuit> CreateOrGetAsync(SubCircuit subCircuit)
    {
        foreach (var child in subCircuit.SubCircuits)
            await CreateOrGetAsync(child);

        var hash = SubCircuitHasher.ComputeAndAssignHash(subCircuit);

        var existingSubCircuit = await GetByHashAsync(hash);
        if (existingSubCircuit != null) 
            return existingSubCircuit;

        var subCircuits = subCircuit.SubCircuits
            .OrderBy(subCircuit => subCircuit.Hash, StringComparer.Ordinal)
            .Select(subCircuit => _dbContext.SubCircuits.Local
                .FirstOrDefault(sc => sc.Hash == subCircuit.Hash) ?? 
                    _dbContext.SubCircuits.Attach(new SubCircuit 
                    { 
                        Id = _dbContext.SubCircuits.First(sc => sc.Hash == subCircuit.Hash).Id, 
                        Hash = subCircuit.Hash 
                    }).Entity)
            .ToList();

        var newSubCircuit = new SubCircuit
        {
            Title = subCircuit.Title,
            Hash = hash,
            Ports = [.. subCircuit.Ports.Select(port => new Port 
            { 
                Title = port.Title, 
                Role = port.Role 
            })],
            LogicGates = await GetLogicGatesWithDbTruthTables(subCircuit.LogicGates),
            SubCircuits = subCircuits,
            Wires = []
        };

        _dbContext.SubCircuits.Add(newSubCircuit);
        await _dbContext.SaveChangesAsync();

        newSubCircuit.ReconnectWiresFromSource(subCircuit);

        await _dbContext.SaveChangesAsync();
        return newSubCircuit;
    }

    public async Task<SubCircuit[]> GetAllByTitleAsync(string title) => 
        await _dbContext.SubCircuits.AsNoTracking().Where(subCircuit => subCircuit.Title == title).ToArrayAsync();

    public async Task<SubCircuit> GetByIdRecursivelyAsync(int id)
    {
        var subCircuit = await GetAsync(id);
        await GetRecursivelyAsync(subCircuit);
        return subCircuit;
    }

    private async Task<SubCircuit> GetByHashAsync(string hash) =>
        await _dbContext.SubCircuits.AsNoTracking().FirstOrDefaultAsync(subCircuit => subCircuit.Hash == hash);

    private async Task<List<LogicGate>> GetLogicGatesWithDbTruthTables(List<LogicGate> logicGates)
    {
        var orderedLogicGates = logicGates.OrderBy(logicGate => logicGate, LogicGateOrderComparer.Instance);
        var list = new List<LogicGate>(orderedLogicGates.Count());

        foreach (var logicGate in orderedLogicGates)
        {
            var truthTable = await truthTableRepository.CreateOrGetAsync(logicGate.TruthTable);
            list.Add(new LogicGate
            {
                TruthTable = truthTable,
                Pins = [.. logicGate.Pins.Select(port => new Pin { Role = port.Role })]
            });
        }

        return list;
    }

    private async Task<SubCircuit> GetAsync(int id)
    {
        var subCircuit = await _dbContext.SubCircuits
            .AsNoTracking()
            .Where(subCircuit => subCircuit.Id == id)
            .Include(subCircuit => subCircuit.Ports)
            .Include(subCircuit => subCircuit.LogicGates)
                .ThenInclude(logicGate => logicGate.Pins)
            .Include(subCircuit => subCircuit.LogicGates)
                .ThenInclude(logicGate => logicGate.TruthTable)
            .Include(subCircuit => subCircuit.Wires)
                .ThenInclude(wire => wire.StartTerminal)
            .Include(subCircuit => subCircuit.Wires)
                .ThenInclude(wire => wire.EndTerminal)
            .SingleAsync();

        subCircuit.SubCircuits = await _dbContext.SubCircuits
            .AsNoTracking()
            .Where(subCircuit => subCircuit.ParentId == id)
            .ToListAsync();

        return subCircuit;
    }

    private async Task GetRecursivelyAsync(SubCircuit subCircuit)
    {
        if (subCircuit?.SubCircuits.Count == 0) 
            return;

        for (int i = 0; i < subCircuit.SubCircuits.Count; i++)
        {
            var childSubCircuitId = subCircuit.SubCircuits[i].Id;
            var childSubCircuit = await GetAsync(childSubCircuitId);
            subCircuit.SubCircuits[i] = childSubCircuit;
            await GetRecursivelyAsync(childSubCircuit);
        }
    }
}