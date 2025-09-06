using SimulationEngine.Application.Services.Interfaces;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Repositories;

namespace SimulationEngine.Application.Services;

public class SubCircuitService(ISubCircuitRepository repository) : BaseService<SubCircuit>(repository), ISubCircuitService
{
    public Task<SubCircuit[]> GetAllByTitle(string title) => repository.GetAllByTitle(title);
}