using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimulationEngine.Domain.Models;

namespace SimulationEngine.Infrastructure.DataModel.Configuration;

internal static class TerminalConfiguration
{
    internal static void Configure(EntityTypeBuilder<Terminal> entity)
    {
        entity
            .UseTptMappingStrategy();

        entity
            .Property(terminal => terminal.Title);
    }
}