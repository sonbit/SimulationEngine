using SimulationEngine.Application.Services.Database.Base;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Repositories;

namespace SimulationEngine.Application.Services.Database.Subcircuits;

public class SubcircuitService(ISubcircuitRepository repository) : BaseService<Subcircuit>(repository), ISubcircuitService
{
    public Task<Subcircuit> GetByTitleAsync(string title) => 
        repository.GetByTitleAsync(title);
}