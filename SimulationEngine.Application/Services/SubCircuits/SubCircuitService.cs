using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Repositories;

namespace SimulationEngine.Application.Services.SubCircuits;

public class SubCircuitService(
    ISubCircuitRepository repository, 
    ITruthTableRepository truthTableRepository,
    IUnitOfWork unitOfWork) : BaseService<SubCircuit>(repository), ISubCircuitService
{
    public override async Task<SubCircuit> CreateAsync(SubCircuit subCircuit) 
    {
        await ProcessTruthTables(subCircuit);
        await base.CreateAsync(subCircuit);
        await unitOfWork.SaveChangesAsync();
        return subCircuit;
    }

    public async Task<SubCircuit[]> GetAllByTitle(string title) => await repository.GetAllByTitleAsync(title);

    public async override Task Populate()
    {
        
    }

    private static HashSet<string> CollectHeptaIndexes(SubCircuit parent)
    {
        return EnumerateAllLogicGates(parent)
            .Where(logicGate => logicGate.TruthTable != null)
            .Select(logicGate => logicGate.TruthTable!.HeptaIndex)
            .ToHashSet(StringComparer.Ordinal);
    }

    private static IEnumerable<LogicGate> EnumerateAllLogicGates(SubCircuit parent)
    {
        foreach (var logicGate in parent.LogicGates)
            yield return logicGate;

        foreach (var subCircuit in parent.SubCircuits ?? [])
        {
            foreach (var logicGate in EnumerateAllLogicGates(subCircuit))
                yield return logicGate;
        }
    }

    //private static async Task InstantiateSubCircuitDesigns(SimulationEngineDbContext dbContext)
    //{
    //    var designsAssembly = typeof(StandardCellLibrary).Assembly;

    //    var designs = designsAssembly
    //        .GetTypes()
    //        .Where(type => type.IsClass && !type.IsAbstract && typeof(SubCircuit).IsAssignableFrom(type))
    //        .ToList();

    //    foreach (var design in designs)
    //    {
    //        var instance = (SubCircuit)Activator.CreateInstance(design, nonPublic: true) ??
    //            throw new InvalidOperationException($"{design.Name} needs a parameterless constructor.");
    //        var exists = await dbContext.SubCircuits.AnyAsync(x => x.Id == instance.Id);
    //        if (!exists)
    //            dbContext.Add(instance);
    //    }

    //    await dbContext.SaveChangesAsync();
    //}

    private async Task ProcessTruthTables(SubCircuit subCircuit)
    {
        var heptaIndexes = CollectHeptaIndexes(subCircuit);

        var existingTruthTables = await truthTableRepository.GetAllByHeptaIndexAsync(heptaIndexes);
        var existingHeptaIndexes = existingTruthTables.ToDictionary(truthTable => truthTable.HeptaIndex, StringComparer.Ordinal);

        truthTableRepository.AttachRange(existingTruthTables);

        foreach (var logicGate in EnumerateAllLogicGates(subCircuit))
        {
            if (logicGate.TruthTable is null)
                continue;

            if (existingHeptaIndexes.TryGetValue(logicGate.TruthTable.HeptaIndex, out var existingTruthTable))
            {
                logicGate.TruthTableId = existingTruthTable.Id;
                logicGate.TruthTable = null;
            }
        }
    }
}