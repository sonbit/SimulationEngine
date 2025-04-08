using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Repositories;
using SimulationEngine.Infrastructure.DataModel;

namespace SimulationEngine.Infrastructure.Repositories
{
    public class LogicGateRepository : IBaseRepository<LogicGate>
    {
        private readonly SimulationEngineDbContext _dbContext;
        
        public LogicGateRepository(SimulationEngineDbContext dbContext) => _dbContext = dbContext;
        
        public async Task Create(LogicGate logicGate)
        {
            await _dbContext.LogicGates.AddAsync(logicGate);
        }

        public async Task<ICollection<LogicGate>> Read()
        {
            return await _dbContext.LogicGates.ToArrayAsync();
        }

        public async Task<LogicGate> Read(int id)
        {
            return await _dbContext.LogicGates.FindAsync(id);
        }

        public async Task Update(int id, LogicGate logicGate)
        {
            var existingLogicGate = await Read(id);
            if (existingLogicGate != null)
                _dbContext.Entry(existingLogicGate).CurrentValues.SetValues(logicGate);
        }

        public async Task Delete(int id)
        {
            var existingLogicGate = await Read(id);
            if (existingLogicGate != null)
                _dbContext.LogicGates.Remove(existingLogicGate);
        }
    }
}