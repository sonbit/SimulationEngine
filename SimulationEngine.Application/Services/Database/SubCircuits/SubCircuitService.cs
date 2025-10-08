using SimulationEngine.Application.Services.Database.Base;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Repositories;

namespace SimulationEngine.Application.Services.Database.SubCircuits;

public class SubCircuitService(ISubCircuitRepository repository) : BaseService<SubCircuit>(repository), ISubCircuitService
{
    public Task<SubCircuit> GetByTitleAsync(string title) => 
        repository.GetByTitleAsync(title);
}