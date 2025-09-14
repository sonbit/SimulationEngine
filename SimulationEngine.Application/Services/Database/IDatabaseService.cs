namespace SimulationEngine.Application.Services.Database;

public interface IDatabaseService
{
    Task<bool> EnsureDatabaseCreatedAsync();
    Task<bool> EnsureDatabaseDeletedAsync();
}