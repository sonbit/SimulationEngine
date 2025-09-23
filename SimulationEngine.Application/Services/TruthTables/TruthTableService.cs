using SimulationEngine.Designs;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Repositories;

namespace SimulationEngine.Application.Services.TruthTables;

public class TruthTableService(ITruthTableRepository repository) : BaseService<TruthTable>(repository), ITruthTableService
{
    public async Task<List<TruthTable>> GetAllByTitle(string title) => await repository.GetAllByTitleAsync(title);

    public async Task<TruthTable> GetAsync(int id) => await repository.GetAsync(id);

    public async Task<TruthTable> GetByHeptaIndex(string heptaIndex) => await repository.GetByHeptaIndexAsync(heptaIndex);

    public async override Task Populate()
    {
        var truthTables = new List<TruthTable>()
            .Concat(StandardCellLibrary.GetArity1().Select(kvp => new TruthTable { HeptaIndex = kvp.Key, Title = kvp.Value }))
            .Concat(StandardCellLibrary.GetArity2().Select(kvp => new TruthTable { HeptaIndex = kvp.Key, Title = kvp.Value }))
            .Concat(StandardCellLibrary.GetArity3().Select(kvp => new TruthTable { HeptaIndex = kvp.Key, Title = kvp.Value }))
            .ToList();

        await repository.CreateOrGetRangeAsync(truthTables);
    }
}