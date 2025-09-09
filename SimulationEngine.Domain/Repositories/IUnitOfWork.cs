using System.Threading.Tasks;

namespace SimulationEngine.Domain.Repositories;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync();
}