using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Repositories;
using SimulationEngine.Infrastructure.DataModel;

namespace SimulationEngine.Infrastructure.Repositories;

public class TruthTableRepository(SimulationEngineDbContext dbContext) : IBaseRepository<TruthTable>
{
    public async Task Create(TruthTable truthTable)
    {
        await dbContext.TruthTables.AddAsync(truthTable);
    }

    public async Task<ICollection<TruthTable>> Read()
    {
        return await dbContext.TruthTables.ToArrayAsync();
    }

    public async Task<TruthTable> Read(int id)
    {
        return await dbContext.TruthTables.FindAsync(id);
    }

    public async Task Update(int id, TruthTable truthTable)
    {
        var existingTruthTable = await Read(id);
        if (existingTruthTable != null)
            dbContext.Entry(existingTruthTable).CurrentValues.SetValues(truthTable);
    }

    public async Task Delete(int id)
    {
        var existingTruthTable = await Read(id);
        if (existingTruthTable != null)
            dbContext.TruthTables.Remove(existingTruthTable);
    }
}