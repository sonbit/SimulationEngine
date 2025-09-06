using Microsoft.EntityFrameworkCore;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Repositories;
using SimulationEngine.Infrastructure.DataModel;
using System.Linq;
using System.Threading.Tasks;

namespace SimulationEngine.Infrastructure.Repositories;

public class TruthTableRepository(SimulationEngineDbContext dbContext) : BaseRepository<TruthTable>(dbContext), ITruthTableRepository
{
    private readonly SimulationEngineDbContext _dbContext = dbContext;

    public Task<TruthTable> GetByHeptaIndex(string heptaIndex) =>
        _dbContext.TruthTables.AsNoTracking().FirstOrDefaultAsync(truthTable => truthTable.HeptaIndex == heptaIndex);

    public Task<TruthTable[]> GetAllByTitle(string title) =>
        _dbContext.TruthTables.AsNoTracking().Where(truthTable => truthTable.Title == title).ToArrayAsync();
}