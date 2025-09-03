using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace SimulationEngine.Infrastructure.DataModel;

public class SimulationEngineDbContextFactory : IDesignTimeDbContextFactory<SimulationEngineDbContext>
{
    public SimulationEngineDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<SimulationEngineDbContext>();
        optionsBuilder.UseSqlite("Data Source=SimulationEngine.db");
        return new SimulationEngineDbContext(optionsBuilder.Options);
    }
}