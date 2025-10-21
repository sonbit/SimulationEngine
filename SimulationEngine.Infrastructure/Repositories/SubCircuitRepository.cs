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

public partial class SubcircuitRepository(SimulationEngineDbContext dbContext, ITruthTableRepository truthTableRepository) : ISubcircuitRepository
{
    public async Task<Subcircuit> CreateOrGetAsync(Subcircuit subcircuit)
    {
        var closure = SubcircuitCompiler.Compile(subcircuit);
        var hash = closure.Placed.Template.Hash;
        await EnsurePersistedAsync(hash, closure);
        return await dbContext.Subcircuits.AsNoTracking().FirstAsync(subcircuit => subcircuit.Hash == hash);
    }

    public async Task<List<Subcircuit>> GetAllAsync() => await GetSubcircuitQuery().ToListAsync();

    public async Task<Subcircuit> GetByIdAsync(int id)
    {
        var (template, placements) = await GetTemplateWithPlacementsAsync(id);
        if (template == null && placements == null)
            return null;

        var subcircuit = await BuildInstanceAsync(template, placements);
        subcircuit.Id = id;

        return subcircuit;
    }

    public async Task<Subcircuit> GetByTitleAsync(string title)
    {
        var titleLowerCase = title.ToLower();
        var subcircuit = await dbContext.Subcircuits
            .FirstOrDefaultAsync(subCiruit => subCiruit.Title.ToLower().Contains(titleLowerCase));

        return await GetByIdAsync(subcircuit?.Id ?? 0);
    }

    private async Task EnsurePersistedAsync(string hash, SubcircuitClosure closure)
    {
        if (await dbContext.Subcircuits.AsNoTracking().AnyAsync(subCircuit => subCircuit.Hash == hash)) 
            return;

        var placed = closure.PlacedByHash[hash];
        foreach (var childTemplateHash in placed.PlacementInfos.Select(p => p.ChildTemplateHash).Distinct(StringComparer.Ordinal))
            await EnsurePersistedAsync(childTemplateHash, closure);

        await PersistTemplateAsync(placed);
    }

    private IIncludableQueryable<Subcircuit, Terminal> GetSubcircuitQuery()
    {
        return dbContext.Subcircuits
            .AsNoTrackingWithIdentityResolution()
            .AsSplitQuery()
            .Include(subcircuit => subcircuit.Ports)
                .ThenInclude(port => port.Metadata)
            .Include(subcircuit => subcircuit.LogicGates)
                .ThenInclude(logicGate => logicGate.Metadata)
            .Include(subcircuit => subcircuit.LogicGates)
                .ThenInclude(logicGate => logicGate.Pins)
            .Include(subcircuit => subcircuit.LogicGates)
                .ThenInclude(logicGate => logicGate.TruthTable)
            .Include(subcircuit => subcircuit.Wires)
                .ThenInclude(wire => wire.StartTerminal)
            .Include(subcircuit => subcircuit.Wires)
                .ThenInclude(wire => wire.EndTerminal);
    }
}