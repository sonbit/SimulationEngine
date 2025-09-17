using SimulationEngine.Domain.Models;

namespace SimulationEngine.Application.Services.SubCircuits;

public interface ISubCircuitService : IBaseService<SubCircuit>
{
    Task<SubCircuit> GetAsync(int id);
}