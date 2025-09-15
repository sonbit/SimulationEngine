using SimulationEngine.Domain.Models;
using System.Threading.Tasks;

namespace SimulationEngine.Domain.Repositories;

public interface ISubCircuitRepository : IBaseRepository<SubCircuit>
{
    Task<SubCircuit[]> GetAllByTitleAsync(string title);
    Task<SubCircuit> GetByIdRecursivelyAsync(int id);
}