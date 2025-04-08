using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Repositories;
using SimulationEngine.Infrastructure.DataModel;

namespace SimulationEngine.Infrastructure.Repositories
{
    public class OutputRepository : IBaseRepository<Output>
    {
        private readonly SimulationEngineDbContext _dbContext;
        
        public OutputRepository(SimulationEngineDbContext dbContext) => _dbContext = dbContext;
        
        public async Task Create(Output output)
        {
            await _dbContext.Outputs.AddAsync(output);
        }

        public async Task<ICollection<Output>> Read()
        {
            return await _dbContext.Outputs.ToArrayAsync();
        }

        public async Task<Output> Read(int id)
        {
            return await _dbContext.Outputs.FindAsync(id);
        }

        public async Task Update(int id, Output output)
        {
            var existingOutput = await Read(id);
            if (existingOutput != null)
                _dbContext.Entry(existingOutput).CurrentValues.SetValues(output);
        }

        public async Task Delete(int id)
        {
            var existingOutput = await Read(id);
            if (existingOutput != null)
                _dbContext.Outputs.Remove(existingOutput);
        }
    }
}