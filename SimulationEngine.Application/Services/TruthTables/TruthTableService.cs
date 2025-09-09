using SimulationEngine.Designs;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Repositories;

namespace SimulationEngine.Application.Services.TruthTables;

public class TruthTableService(
    ITruthTableRepository repository,
    IUnitOfWork unitOfWork) : BaseService<TruthTable>(repository), ITruthTableService
{
    public override async Task<TruthTable> CreateAsync(TruthTable truthTable) 
    {
        var existingTruthTable = await repository.GetByHeptaIndexAsync(truthTable.HeptaIndex);
        if (existingTruthTable is not null)
            return existingTruthTable;

        await base.CreateAsync(truthTable);
        await unitOfWork.SaveChangesAsync();

        return truthTable;
    }

    public async Task<TruthTable[]> GetAllByTitle(string title) => await repository.GetAllByTitleAsync(title);

    public async Task<TruthTable> GetByHeptaIndex(string heptaIndex) => await repository.GetByHeptaIndexAsync(heptaIndex);

    public async override Task Populate()
    {
        var truthTables = new List<TruthTable>()
            .Concat(StandardCellLibrary.GetArity1().Select(kvp => new TruthTable { HeptaIndex = kvp.Key, Title = kvp.Value }))
            .Concat(StandardCellLibrary.GetArity2().Select(kvp => new TruthTable { HeptaIndex = kvp.Key, Title = kvp.Value }))
            .Concat(StandardCellLibrary.GetArity3().Select(kvp => new TruthTable { HeptaIndex = kvp.Key, Title = kvp.Value }));

        await repository.CreateRangeAsync(truthTables);
    }
}
