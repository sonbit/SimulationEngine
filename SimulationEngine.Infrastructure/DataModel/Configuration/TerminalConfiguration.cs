using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Enums;

namespace SimulationEngine.Infrastructure.DataModel.Configuration;

internal static class TerminalConfiguration
{
    internal static void Configure(EntityTypeBuilder<Terminal> entity)
    {
        entity
            .Property(terminal => terminal.Title)
            .HasMaxLength(100);

        entity.Property(terminal => terminal.Type)
            .HasConversion<string>()
            .HasMaxLength(4)
            .IsUnicode(false);

        entity
            .HasDiscriminator(terminal => terminal.Type)
            .HasValue<Pin>(TerminalType.Pin)
            .HasValue<Port>(TerminalType.Port);
    }
}