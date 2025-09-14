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

    private async Task<SubCircuit> GetByHashAsync(string hash, CancellationToken ct = default) =>
        await _dbContext.SubCircuits.AsNoTracking().FirstOrDefaultAsync(s => s.Hash == hash, ct);

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
}