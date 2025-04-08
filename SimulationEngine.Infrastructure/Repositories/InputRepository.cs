using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Repositories;
using SimulationEngine.Infrastructure.DataModel;

namespace SimulationEngine.Infrastructure.Repositories
{
    public class InputRepository : IBaseRepository<Input>
    {
        private readonly SimulationEngineDbContext _dbContext;
        
        public InputRepository(SimulationEngineDbContext dbContext) => _dbContext = dbContext;
        
        public async Task Create(Input input)
        {
            await _dbContext.Inputs.AddAsync(input);
        }

        public async Task<ICollection<Input>> Read()
        {
            return await _dbContext.Inputs.ToArrayAsync();
        }

        public async Task<Input> Read(int id)
        {
            return await _dbContext.Inputs.FindAsync(id);
        }

        public async Task Update(int id, Input input)
        {
            var existingInput = await Read(id);
            if (existingInput != null)
                _dbContext.Entry(existingInput).CurrentValues.SetValues(input);
        }

        public async Task Delete(int id)
        {
            var existingInput = await Read(id);
            if (existingInput != null)
                _dbContext.Inputs.Remove(existingInput);
        }
    }
}