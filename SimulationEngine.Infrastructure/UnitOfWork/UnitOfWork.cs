using SimulationEngine.Domain.Repositories;
using SimulationEngine.Infrastructure.DataModel;
using System.Threading.Tasks;

namespace SimulationEngine.Infrastructure.UnitOfWork;

public class UnitOfWork(SimulationEngineDbContext dbContext) : IUnitOfWork
{
    public async Task<int> SaveChangesAsync() => await dbContext.SaveChangesAsync();
}
