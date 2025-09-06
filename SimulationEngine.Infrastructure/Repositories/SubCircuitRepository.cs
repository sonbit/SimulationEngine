using Microsoft.EntityFrameworkCore;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Repositories;
using SimulationEngine.Infrastructure.DataModel;
using System.Linq;
using System.Threading.Tasks;

namespace SimulationEngine.Infrastructure.Repositories;

public class SubCircuitRepository(SimulationEngineDbContext dbContext) : BaseRepository<SubCircuit>(dbContext), ISubCircuitRepository
{
    private readonly SimulationEngineDbContext _dbContext = dbContext;

    public Task<SubCircuit[]> GetAllByTitle(string title) =>
        _dbContext.SubCircuits.AsNoTracking().Where(subCircuit => subCircuit.Title == title).ToArrayAsync();
}