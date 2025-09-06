using SimulationEngine.Domain.Models;
using System.Threading.Tasks;

namespace SimulationEngine.Domain.Repositories;

public interface ISubCircuitRepository : IBaseRepository<SubCircuit>
{
    Task<SubCircuit[]> GetAllByTitle(string title);
}