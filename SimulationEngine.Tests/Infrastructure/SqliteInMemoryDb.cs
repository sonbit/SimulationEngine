using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using SimulationEngine.Infrastructure.DataModel;

namespace SimulationEngine.Tests.Infrastructure;

public sealed class SqliteInMemoryDb : IDisposable
{
    public SqliteInMemoryDb()
    {
        Connection = new SqliteConnection("Filename=:memory:");
        Connection.Open();

        Options = new DbContextOptionsBuilder<SimulationEngineDbContext>()
            .UseSqlite(Connection)
            .EnableSensitiveDataLogging()
            .Options;

        using var ctx = new SimulationEngineDbContext(Options);
        ctx.Database.EnsureCreated();
    }

    public SqliteConnection Connection { get; }
    public DbContextOptions<SimulationEngineDbContext> Options { get; }

    public SimulationEngineDbContext NewContext() => new(Options);

    public void Dispose() => Connection.Dispose();
}