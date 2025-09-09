using SimulationEngine.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimulationEngine.Domain.Repositories;

public interface ITruthTableRepository : IBaseRepository<TruthTable>
{
    void AttachRange(TruthTable[] truthTables);
    Task<TruthTable[]> GetAllByTitleAsync(string title);
    Task<TruthTable[]> GetAllByHeptaIndexAsync(HashSet<string> heptaIndexes);
    Task<TruthTable> GetByHeptaIndexAsync(string heptaIndex);
}