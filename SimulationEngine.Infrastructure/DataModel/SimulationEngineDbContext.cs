using Microsoft.EntityFrameworkCore;
using SimulationEngine.Domain.Models;
using SimulationEngine.Infrastructure.DataModel.Configuration;

namespace SimulationEngine.Infrastructure.DataModel
{
    public class SimulationEngineDbContext : DbContext
    {
        public SimulationEngineDbContext()
        {
            
        }
        
        public SimulationEngineDbContext(DbContextOptions<SimulationEngineDbContext> options) : base(options)
        {
            
        }
        
        public DbSet<Input> Inputs { get; set; }
        public DbSet<LogicGate> LogicGates { get; set; }
        public DbSet<Output> Outputs { get; set; }
        public DbSet<Port> Ports { get; set; }
        public DbSet<SubCircuit> SubCircuits { get; set; }
        public DbSet<TruthTable> TruthTables { get; set; }
        public DbSet<Wire> Wires { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Input>(InputConfiguration.Configure);
            modelBuilder.Entity<LogicGate>(LogicGateConfiguration.Configure);
            modelBuilder.Entity<Output>(OutputConfiguration.Configure);
            modelBuilder.Entity<Port>(PortConfiguration.Configure);
            modelBuilder.Entity<SubCircuit>(SubCircuitConfiguration.Configure);
            modelBuilder.Entity<TruthTable>(TruthTableConfiguration.Configure);
            modelBuilder.Entity<Wire>(WireConfiguration.Configure);
            
            base.OnModelCreating(modelBuilder);
        }
    }
}