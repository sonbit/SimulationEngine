using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Repositories;
using SimulationEngine.Infrastructure.DataModel;

namespace SimulationEngine.Infrastructure.Repositories;

public class TerminalRepository(SimulationEngineDbContext dbContext) : IBaseRepository<Terminal>
{
    public async Task Create(Terminal port)
    {
        await dbContext.Terminals.AddAsync(port);
    }

    public async Task<ICollection<Terminal>> Read()
    {
        return await dbContext.Terminals.ToArrayAsync();
    }

    public async Task<Terminal> Read(int id)
    {
        return await dbContext.Terminals.FindAsync(id);
    }

    public async Task Update(int id, Terminal terminal)
    {
        var existingTerminal = await Read(id);
        if (existingTerminal != null)
            dbContext.Entry(existingTerminal).CurrentValues.SetValues(terminal);
    }

    public async Task Delete(int id)
    {
        var existingTerminal = await Read(id);
        if (existingTerminal != null)
            dbContext.Terminals.Remove(existingTerminal);
    }
}