using SimulationEngine.Domain.Models;

namespace SimulationEngine.Application.Services.Interfaces;

public interface ISubCircuitService : IBaseService<SubCircuit>
{
    Task<SubCircuit[]> GetAllByTitle(string title);
}