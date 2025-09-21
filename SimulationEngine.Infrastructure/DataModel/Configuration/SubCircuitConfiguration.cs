using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimulationEngine.Domain.Models;

namespace SimulationEngine.Infrastructure.DataModel.Configuration;

internal static class SubCircuitConfiguration
{
    internal static void Configure(EntityTypeBuilder<SubCircuit> entity)
    {
        entity
            .Property(subCircuit => subCircuit.Title)
            .HasMaxLength(100);

        entity
            .Property(subCircuit => subCircuit.Hash)
            .HasMaxLength(64);

        entity
            .HasMany(subCircuit => subCircuit.Ports)
            .WithOne(port => port.SubCircuit)
            .HasForeignKey(port => port.SubCircuitId);

        entity
            .HasMany(subCircuit => subCircuit.Wires)
            .WithOne(wire => wire.SubCircuit)
            .HasForeignKey(wire => wire.SubCircuitId);

        entity
            .HasIndex(subCircuit => subCircuit.Hash)
            .IsUnique();
    }
}