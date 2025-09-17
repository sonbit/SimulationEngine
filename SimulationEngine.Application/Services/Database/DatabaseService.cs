
using SimulationEngine.Domain.Repositories;

namespace SimulationEngine.Application.Services.Database;

public class DatabaseService(IUnitOfWork unitOfWork) : IDatabaseService
{
    public async Task<bool> EnsureDatabaseCreatedAsync() => await unitOfWork.EnsureDatabaseCreatedAsync();

    public async Task<bool> EnsureDatabaseDeletedAsync() => await unitOfWork.EnsureDatabaseDeletedAsync();

    public async Task<bool> EnsureDatabaseRecreatedAsync() 
    {
        var isDatabaseDeleted = await unitOfWork.EnsureDatabaseDeletedAsync();
        var isDatabaseCreated = await unitOfWork.EnsureDatabaseCreatedAsync();
        return isDatabaseDeleted && isDatabaseCreated;
    }
}