using Microsoft.EntityFrameworkCore;
using SimulationEngine.Domain.Models;
using SimulationEngine.Infrastructure.DataModel.Configuration;
using SimulationEngine.Infrastructure.DataModel.Extensions;

namespace SimulationEngine.Infrastructure.DataModel;

public class SimulationEngineDbContext : DbContext
{
    public SimulationEngineDbContext() { }
    
    public SimulationEngineDbContext(DbContextOptions<SimulationEngineDbContext> options) : base(options) { }
    
    public DbSet<LogicGate> LogicGates { get; set; }
    //public DbSet<Pin> Pins => Set<Pin>();
    //public DbSet<Port> Ports => Set<Port>();
    public DbSet<SubCircuit> SubCircuits { get; set; }
    public DbSet<Terminal> Terminals { get; set; }
    public DbSet<TruthTable> TruthTables { get; set; }
    public DbSet<Wire> Wires { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<LogicGate>(LogicGateConfiguration.Configure);
        modelBuilder.Entity<Pin>(PinConfiguration.Configure);
        modelBuilder.Entity<Port>(PortConfiguration.Configure);
        modelBuilder.Entity<SubCircuit>(SubCircuitConfiguration.Configure);
        modelBuilder.Entity<Terminal>(TerminalConfiguration.Configure);
        modelBuilder.Entity<TruthTable>(TruthTableConfiguration.Configure);
        modelBuilder.Entity<Wire>(WireConfiguration.Configure);

        modelBuilder.ApplyBaseConfiguration();
        
        base.OnModelCreating(modelBuilder);
    }
}