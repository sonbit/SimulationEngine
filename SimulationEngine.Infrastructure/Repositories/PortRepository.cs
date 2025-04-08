using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Repositories;
using SimulationEngine.Infrastructure.DataModel;

namespace SimulationEngine.Infrastructure.Repositories
{
    public class PortRepository : IBaseRepository<Port>
    {
        private readonly SimulationEngineDbContext _dbContext;
        
        public PortRepository(SimulationEngineDbContext dbContext) => _dbContext = dbContext;
        
        public async Task Create(Port port)
        {
            await _dbContext.Ports.AddAsync(port);
        }

        public async Task<ICollection<Port>> Read()
        {
            return await _dbContext.Ports.ToArrayAsync();
        }

        public async Task<Port> Read(int id)
        {
            return await _dbContext.Ports.FindAsync(id);
        }

        public async Task Update(int id, Port port)
        {
            var existingPort = await Read(id);
            if (existingPort != null)
                _dbContext.Entry(existingPort).CurrentValues.SetValues(port);
        }

        public async Task Delete(int id)
        {
            var existingPort = await Read(id);
            if (existingPort != null)
                _dbContext.Ports.Remove(existingPort);
        }
    }
}