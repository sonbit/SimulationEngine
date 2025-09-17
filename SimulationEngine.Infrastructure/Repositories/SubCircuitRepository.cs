using Microsoft.EntityFrameworkCore;
using SimulationEngine.Domain.Compilers;
using SimulationEngine.Domain.Compilers.Models;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Repositories;
using SimulationEngine.Infrastructure.DataModel;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SimulationEngine.Infrastructure.Repositories;

public partial class SubCircuitRepository(
    SimulationEngineDbContext dbContext,
    ITruthTableRepository truthTableRepository) : BaseRepository<SubCircuit>(dbContext), ISubCircuitRepository
{
    private readonly SimulationEngineDbContext _dbContext = dbContext;

    public override async Task<SubCircuit> CreateOrGetAsync(SubCircuit subCircuit)
    {
        var subCircuitClosure = SubCircuitCompiler.Compile(subCircuit);
        var hash = subCircuitClosure.SubCircuitPlaced.SubCircuit.Hash;
        await EnsurePersistedAsync(hash, subCircuitClosure);
        return await _dbContext.SubCircuits.AsNoTracking().FirstAsync(subCircuit => subCircuit.Hash == hash);
    }

    public async Task<SubCircuit> GetAsync(int id)
    {
        var (template, subCircuitPlacements) = await GetSubCircuitWithChildren(id);
        var subCircuit = await BuildInstanceFromTemplateAsync(template, subCircuitPlacements);
        return subCircuit;
    }

    private async Task EnsurePersistedAsync(string hash, SubCircuitClosure subCircuitClosure)
    {
        if (await _dbContext.SubCircuits.AsNoTracking().AnyAsync(s => s.Hash == hash)) return;

        var placed = subCircuitClosure.MapByHash[hash];
        foreach (var childHash in placed.SubCircuitPlacementInfos.Select(p => p.ChildSubCircuitHash).Distinct(StringComparer.Ordinal))
            await EnsurePersistedAsync(childHash, subCircuitClosure);

        await PersistPlacedAsync(placed);
    }
}