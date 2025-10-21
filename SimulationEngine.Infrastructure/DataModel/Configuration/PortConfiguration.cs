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
            .HasOne(port => port.Subcircuit)
            .WithMany(subcircuit => subcircuit.Ports)
            .HasForeignKey(port => port.SubcircuitId);

        entity
            .HasIndex(port => new { port.SubcircuitId, port.Direction, port.Ordinal })
            .IsUnique();
    }
}