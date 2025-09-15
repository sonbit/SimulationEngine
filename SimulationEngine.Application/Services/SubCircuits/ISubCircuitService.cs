using SimulationEngine.Domain.Models;

namespace SimulationEngine.Application.Services.SubCircuits;

public interface ISubCircuitService : IBaseService<SubCircuit>
{
    Task<SubCircuit[]> GetAllByTitle(string title);
    Task<SubCircuit> GetByIdRecursively(int id);
}