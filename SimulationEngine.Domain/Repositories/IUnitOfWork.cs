using System.Threading.Tasks;

namespace SimulationEngine.Domain.Repositories;

public interface IUnitOfWork
{
    Task<bool> EnsureDatabaseCreatedAsync();
    Task<bool> EnsureDatabaseDeletedAsync();
    Task<int> SaveChangesAsync();
}