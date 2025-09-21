using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimulationEngine.Domain.Models.Metadata;

namespace SimulationEngine.Infrastructure.DataModel.Configuration.Metadata;

internal class PortMetadataConfiguration
{
    internal static void Configure(EntityTypeBuilder<PortMetadata> entity)
    {
        entity
            .Property(portMetadata => portMetadata.Radix)
            .HasConversion<string>()
            .HasColumnName(nameof(PortMetadata.Radix))
            .IsRequired();
    }
}