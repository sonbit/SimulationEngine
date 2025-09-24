using SimulationEngine.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimulationEngine.Domain.Repositories;

public interface ITruthTableRepository : IBaseRepository<TruthTable>
{
    Task<List<TruthTable>> CreateOrGetRangeAsync(List<TruthTable> truthTables);
    Task<TruthTable> GetByHeptaIndexAsync(string heptaIndex);
}