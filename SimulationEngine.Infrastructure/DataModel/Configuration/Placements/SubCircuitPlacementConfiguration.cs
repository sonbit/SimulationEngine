using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimulationEngine.Domain.Models.Placements;

namespace SimulationEngine.Infrastructure.DataModel.Configuration.Placements;

internal static class SubCircuitPlacementConfiguration
{
    internal static void Configure(EntityTypeBuilder<SubCircuitPlacement> entity)
    {
        entity
            .HasOne(subCircuit => subCircuit.ParentSubCircuit)
            .WithMany()
            .HasForeignKey(subCircuit => subCircuit.ParentSubCircuitId);

        entity
            .HasOne(subCircuit => subCircuit.ChildSubCircuit)
            .WithMany()
            .HasForeignKey(subCircuit => subCircuit.ChildSubCircuitId);

        entity
            .HasIndex(subCircuit => new { subCircuit.ParentSubCircuitId, subCircuit.Ordinal })
            .IsUnique();
    }
}