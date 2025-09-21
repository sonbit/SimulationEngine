using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimulationEngine.Domain.Models.Metadata;

namespace SimulationEngine.Infrastructure.DataModel.Configuration.Metadata;

internal class LogicGateMetadataConfiguration
{
    internal static void Configure(EntityTypeBuilder<LogicGateMetadata> entity)
    {
        entity
            .Property(logicGateMetadata => logicGateMetadata.Radix)
            .HasConversion<string>()
            .HasColumnName(nameof(LogicGateMetadata.Radix))
            .IsRequired();
    }
}