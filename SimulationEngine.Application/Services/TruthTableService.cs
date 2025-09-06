using SimulationEngine.Application.Services.Interfaces;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Repositories;

namespace SimulationEngine.Application.Services;

public class TruthTableService(ITruthTableRepository repository) : BaseService<TruthTable>(repository), ITruthTableService
{
    public Task<TruthTable[]> GetAllByTitle(string title) => repository.GetAllByTitle(title);

    public Task<TruthTable> GetByHeptaIndex(string heptaIndex) => repository.GetByHeptaIndex(heptaIndex);
}
