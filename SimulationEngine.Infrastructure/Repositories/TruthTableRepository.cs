using Microsoft.EntityFrameworkCore;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Repositories;
using SimulationEngine.Infrastructure.DataModel;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimulationEngine.Infrastructure.Repositories;

public class TruthTableRepository(SimulationEngineDbContext dbContext) : BaseRepository<TruthTable>(dbContext), ITruthTableRepository
{
    private readonly SimulationEngineDbContext _dbContext = dbContext;

    public void AttachRange(TruthTable[] truthTables) => _dbContext.TruthTables.AttachRange(truthTables);

    public async Task<TruthTable> GetByHeptaIndexAsync(string heptaIndex) =>
        await _dbContext.TruthTables.AsNoTracking().FirstOrDefaultAsync(truthTable => truthTable.HeptaIndex == heptaIndex);

    public async Task<TruthTable[]> GetAllByHeptaIndexAsync(HashSet<string> heptaIndexes) => 
        await _dbContext.TruthTables.AsNoTracking().Where(truthTable => heptaIndexes.Contains(truthTable.HeptaIndex)).ToArrayAsync();

    public async Task<TruthTable[]> GetAllByTitleAsync(string title) =>
        await _dbContext.TruthTables.AsNoTracking().Where(truthTable => truthTable.Title == title).ToArrayAsync();
}