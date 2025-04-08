using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Repositories;
using SimulationEngine.Infrastructure.DataModel;

namespace SimulationEngine.Infrastructure.Repositories
{
    public class TruthTableRepository : IBaseRepository<TruthTable>
    {
        private readonly SimulationEngineDbContext _dbContext;
        
        public TruthTableRepository(SimulationEngineDbContext dbContext) => _dbContext = dbContext;
        
        public async Task Create(TruthTable truthTable)
        {
            await _dbContext.TruthTables.AddAsync(truthTable);
        }

        public async Task<ICollection<TruthTable>> Read()
        {
            return await _dbContext.TruthTables.ToArrayAsync();
        }

        public async Task<TruthTable> Read(int id)
        {
            return await _dbContext.TruthTables.FindAsync(id);
        }

        public async Task Update(int id, TruthTable truthTable)
        {
            var existingTruthTable = await Read(id);
            if (existingTruthTable != null)
                _dbContext.Entry(existingTruthTable).CurrentValues.SetValues(truthTable);
        }

        public async Task Delete(int id)
        {
            var existingTruthTable = await Read(id);
            if (existingTruthTable != null)
                _dbContext.TruthTables.Remove(existingTruthTable);
        }
    }
}