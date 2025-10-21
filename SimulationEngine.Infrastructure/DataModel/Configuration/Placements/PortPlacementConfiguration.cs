using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimulationEngine.Domain.Models.Placements;

namespace SimulationEngine.Infrastructure.DataModel.Configuration.Placements;

internal static class PortPlacementConfiguration
{
    internal static void Configure(EntityTypeBuilder<PortPlacement> entity)
    {
        entity
            .Property(port => port.IsInput)
            .IsRequired();

        entity
            .Property(port => port.IndexWithinChild)
            .IsRequired();

        entity
            .HasOne(port => port.SubcircuitPlacement)
            .WithMany(subcircuit => subcircuit.PortPlacements)
            .HasForeignKey(port => port.SubcircuitPlacementId);

        entity
            .HasIndex(port => new { port.SubcircuitPlacementId, port.IsInput, port.IndexWithinChild })
            .IsUnique();
    }
}