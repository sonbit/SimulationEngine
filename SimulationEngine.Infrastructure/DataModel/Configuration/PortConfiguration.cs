using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimulationEngine.Domain.Models;

namespace SimulationEngine.Infrastructure.DataModel.Configuration;

internal class PortConfiguration
{
    internal static void Configure(EntityTypeBuilder<Port> entity)
    {
        entity
            .Property(port => port.Direction)
            .HasConversion<string>()
            .HasColumnName(nameof(Port.Direction))
            .IsRequired();

        entity
            .HasOne(port => port.SubCircuit)
            .WithMany(subCircuit => subCircuit.Ports)
            .HasForeignKey(port => port.SubCircuitId);

        entity
            .HasIndex(port => new { port.SubCircuitId, port.Direction, port.Ordinal })
            .IsUnique();
    }
}