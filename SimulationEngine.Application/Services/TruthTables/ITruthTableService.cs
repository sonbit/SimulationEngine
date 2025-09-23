using SimulationEngine.Domain.Models;

namespace SimulationEngine.Application.Services.TruthTables;

public interface ITruthTableService : IBaseService<TruthTable>
{
    Task<List<TruthTable>> GetAllByTitle(string title);
    Task<TruthTable> GetAsync(int id);
    Task<TruthTable> GetByHeptaIndex(string heptaIndex);
}