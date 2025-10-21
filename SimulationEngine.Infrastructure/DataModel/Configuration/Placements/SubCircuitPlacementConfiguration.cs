using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimulationEngine.Domain.Models.Placements;

namespace SimulationEngine.Infrastructure.DataModel.Configuration.Placements;

internal static class SubcircuitPlacementConfiguration
{
    internal static void Configure(EntityTypeBuilder<SubcircuitPlacement> entity)
    {
        entity
            .HasOne(subcircuit => subcircuit.ParentTemplate)
            .WithMany()
            .HasForeignKey(subcircuit => subcircuit.ParentTemplateId);

        entity
            .HasOne(subcircuit => subcircuit.ChildTemplate)
            .WithMany()
            .HasForeignKey(subcircuit => subcircuit.ChildTemplateId);

        entity
            .HasIndex(subcircuit => new { subcircuit.ParentTemplateId, subcircuit.Ordinal })
            .IsUnique();
    }
}