using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimulationEngine.Domain.Models;

namespace SimulationEngine.Infrastructure.DataModel.Configuration;

internal static class PortPlacementConfiguration
{
    internal static void Configure(EntityTypeBuilder<PortPlacement> entity)
    {
        //entity
        //    .ToTable($"{nameof(PortPlacement)}s");

        entity
            .Property(port => port.IsInput)
            .IsRequired();

        entity
            .Property(port => port.IndexWithinChild)
            .IsRequired();

        entity
            .HasOne(port => port.SubCircuitPlacement)
            .WithMany(subCircuit => subCircuit.PortPlacements)
            .HasForeignKey(port => port.SubCircuitPlacementId);

        entity
            .HasIndex(port => new { port.SubCircuitPlacementId, port.IsInput, port.IndexWithinChild })
            .IsUnique();
    }
}