using SimulationEngine.Domain.Models;

namespace SimulationEngine.Application.Services.Interfaces;

public interface ITruthTableService : IBaseService<TruthTable>
{
    Task<TruthTable[]> GetAllByTitle(string title);
    Task<TruthTable> GetByHeptaIndex(string heptaIndex);
}