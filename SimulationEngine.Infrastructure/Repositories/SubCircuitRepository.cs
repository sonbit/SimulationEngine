using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Repositories;
using SimulationEngine.Infrastructure.DataModel;

namespace SimulationEngine.Infrastructure.Repositories
{
    public class SubCircuitRepository : IBaseRepository<SubCircuit>
    {
        private readonly SimulationEngineDbContext _dbContext;
        
        public SubCircuitRepository(SimulationEngineDbContext dbContext) => _dbContext = dbContext;
        
        public async Task Create(SubCircuit subCircuit)
        {
            await _dbContext.SubCircuits.AddAsync(subCircuit);
        }

        public async Task<ICollection<SubCircuit>> Read()
        {
            return await _dbContext.SubCircuits.ToArrayAsync();
        }

        public async Task<SubCircuit> Read(int id)
        {
            return await _dbContext.SubCircuits.FindAsync(id);
        }

        public async Task Update(int id, SubCircuit subCircuit)
        {
            var existingSubCircuit = await Read(id);
            if (existingSubCircuit != null)
                _dbContext.Entry(existingSubCircuit).CurrentValues.SetValues(subCircuit);
        }

        public async Task Delete(int id)
        {
            var existingSubCircuit = await Read(id);
            if (existingSubCircuit != null)
                _dbContext.SubCircuits.Remove(existingSubCircuit);
        }
    }
}