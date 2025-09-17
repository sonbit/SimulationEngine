using SimulationEngine.Domain.Repositories;
using SimulationEngine.Infrastructure.DataModel;
using System.Threading.Tasks;

namespace SimulationEngine.Infrastructure.UnitOfWork;

public class UnitOfWork(SimulationEngineDbContext dbContext) : IUnitOfWork
{
    public async Task<bool> EnsureDatabaseCreatedAsync() => await dbContext.Database.EnsureCreatedAsync();

    public async Task<bool> EnsureDatabaseDeletedAsync()
    {
        var isDatabaseDeleted = await dbContext.Database.EnsureDeletedAsync();
        if (isDatabaseDeleted)
            dbContext.ChangeTracker.Clear();
        return isDatabaseDeleted;
    }

    public async Task<int> SaveChangesAsync() => await dbContext.SaveChangesAsync();
}