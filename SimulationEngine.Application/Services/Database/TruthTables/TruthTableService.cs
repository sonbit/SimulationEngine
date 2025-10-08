using SimulationEngine.Application.Services.Database.Base;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Repositories;

namespace SimulationEngine.Application.Services.Database.TruthTables;

public class TruthTableService(ITruthTableRepository repository) : BaseService<TruthTable>(repository), ITruthTableService
{
    public async Task<List<TruthTable>> CreateOrGetRangeAsync(List<TruthTable> truthTables) => 
        await repository.CreateOrGetRangeAsync(truthTables);

    public async Task<TruthTable> GetByHeptaIndex(string heptaIndex) => 
        await repository.GetByHeptaIndexAsync(heptaIndex);
}