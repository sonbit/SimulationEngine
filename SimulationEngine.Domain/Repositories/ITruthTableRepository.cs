using SimulationEngine.Domain.Models;
using System.Threading.Tasks;

namespace SimulationEngine.Domain.Repositories;

public interface ITruthTableRepository : IBaseRepository<TruthTable>
{
    Task<TruthTable[]> GetAllByTitle(string title);
    Task<TruthTable> GetByHeptaIndex(string heptaIndex);
}