using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimulationEngine.Domain.Models;

namespace SimulationEngine.Infrastructure.DataModel.Configuration;

internal static class SubcircuitConfiguration
{
    internal static void Configure(EntityTypeBuilder<Subcircuit> entity)
    {
        entity
            .Property(subcircuit => subcircuit.Title)
            .HasMaxLength(100);

        entity
            .Property(subcircuit => subcircuit.Hash)
            .HasMaxLength(64);

        entity
            .HasMany(subcircuit => subcircuit.Ports)
            .WithOne(port => port.Subcircuit)
            .HasForeignKey(port => port.SubcircuitId);

        entity
            .HasMany(subcircuit => subcircuit.Wires)
            .WithOne(wire => wire.Subcircuit)
            .HasForeignKey(wire => wire.SubcircuitId);

        entity
            .HasIndex(subcircuit => subcircuit.Hash)
            .IsUnique();
    }
}