using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimulationEngine.Domain.Models;

namespace SimulationEngine.Infrastructure.DataModel.Configuration
{
    internal static class OutputConfiguration
    {
        internal static void Configure(EntityTypeBuilder<Output> entity)
        {
            entity
                .ToTable($"{nameof(Output).ToLower()}s")
                .HasKey(output => output.Id);

            entity
                .Property(input => input.Id)
                .ValueGeneratedOnAdd();

            entity
                .HasMany(input => input.Ports)
                .WithOne(port => port.Output)
                .HasForeignKey(port => port.OutputId);
            
            entity
                .HasOne(input => input.SubCircuit)
                .WithMany(subCircuit => subCircuit.Outputs)
                .HasForeignKey(input => input.SubCircuitId);
        }
    }
}