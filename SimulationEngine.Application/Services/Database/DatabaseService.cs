
using SimulationEngine.Domain.Repositories;

namespace SimulationEngine.Application.Services.Database;

public class DatabaseService(IUnitOfWork unitOfWork) : IDatabaseService
{
    public async Task<bool> EnsureDatabaseCreatedAsync() => await unitOfWork.EnsureDatabaseCreatedAsync();

    public async Task<bool> EnsureDatabaseDeletedAsync() => await unitOfWork.EnsureDatabaseDeletedAsync();
}