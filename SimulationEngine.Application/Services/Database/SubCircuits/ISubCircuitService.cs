using SimulationEngine.Application.Services.Database.Base;
using SimulationEngine.Domain.Models;

namespace SimulationEngine.Application.Services.Database.Subcircuits;

public interface ISubcircuitService : IBaseService<Subcircuit> 
{
    Task<Subcircuit> GetByTitleAsync(string title);
}