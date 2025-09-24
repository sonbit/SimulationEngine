using SimulationEngine.Application.Services.Database.Base;
using SimulationEngine.Domain.Models;

namespace SimulationEngine.Application.Services.Database.SubCircuits;

public interface ISubCircuitService : IBaseService<SubCircuit> 
{
    Task<SubCircuit> GetByTitleAsync(string title);
}