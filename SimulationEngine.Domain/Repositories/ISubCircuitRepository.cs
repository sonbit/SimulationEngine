using SimulationEngine.Domain.Models;
using System.Threading.Tasks;

namespace SimulationEngine.Domain.Repositories;

public interface ISubcircuitRepository : IBaseRepository<Subcircuit> 
{
    Task<Subcircuit> GetByTitleAsync(string title);
}