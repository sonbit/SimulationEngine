using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Repositories;
using SimulationEngine.Infrastructure.DataModel;

namespace SimulationEngine.Infrastructure.Repositories
{
    public class WireRepository : IBaseRepository<Wire>
    {
        private readonly SimulationEngineDbContext _dbContext;
        
        public WireRepository(SimulationEngineDbContext dbContext) => _dbContext = dbContext;
        
        public async Task Create(Wire wire)
        {
            await _dbContext.Wires.AddAsync(wire);
        }

        public async Task<ICollection<Wire>> Read()
        {
            return await _dbContext.Wires.ToArrayAsync();
        }

        public async Task<Wire> Read(int id)
        {
            return await _dbContext.Wires.FindAsync(id);
        }

        public async Task Update(int id, Wire wire)
        {
            var existingWire = await Read(id);
            if (existingWire != null)
                _dbContext.Entry(existingWire).CurrentValues.SetValues(wire);
        }

        public async Task Delete(int id)
        {
            var existingWire = await Read(id);
            if (existingWire != null)
                _dbContext.Wires.Remove(existingWire);
        }
    }
}