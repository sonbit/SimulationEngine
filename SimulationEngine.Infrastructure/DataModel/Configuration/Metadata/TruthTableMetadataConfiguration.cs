using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimulationEngine.Domain.Models.Metadata;

namespace SimulationEngine.Infrastructure.DataModel.Configuration.Metadata;

internal class TruthTableMetadataConfiguration
{
    internal static void Configure(EntityTypeBuilder<TruthTableMetadata> entity)
    {
        entity
            .Property(truthTableMetadata => truthTableMetadata.Radix)
            .HasConversion<string>()
            .HasColumnName(nameof(TruthTableMetadata.Radix))
            .IsRequired();
    }
}