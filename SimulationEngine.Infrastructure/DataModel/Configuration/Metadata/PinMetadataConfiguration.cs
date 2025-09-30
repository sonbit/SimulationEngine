using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimulationEngine.Domain.Models.Metadata;

namespace SimulationEngine.Infrastructure.DataModel.Configuration.Metadata;

internal class PinMetadataConfiguration
{
    internal static void Configure(EntityTypeBuilder<PinMetadata> entity)
    {
        entity
            .Property(pinMetadata => pinMetadata.Radix)
            .HasConversion<string>()
            .HasColumnName(nameof(PinMetadata.Radix))
            .IsRequired();
    }
}