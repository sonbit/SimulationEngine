using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimulationEngine.Domain.Models;

namespace SimulationEngine.Infrastructure.DataModel.Configuration;

internal static class WireConfiguration
{
    internal static void Configure(EntityTypeBuilder<Wire> entity)
    {
        entity
            .HasOne(wire => wire.StartTerminal)
            .WithMany()
            .HasForeignKey(wire => wire.StartTerminalId);

        entity
            .HasOne(wire => wire.EndTerminal)
            .WithOne()
            .HasForeignKey<Wire>(wire => wire.EndTerminalId);

        entity
            .HasOne(wire => wire.SubCircuit)
            .WithMany(subCircuit => subCircuit.Wires)
            .HasForeignKey(wire => wire.SubCircuitId);

        entity
            .HasIndex(w => new { w.SubCircuitId, w.StartTerminalId, w.EndTerminalId }).IsUnique();

        entity
            .ToTable(table => table.HasCheckConstraint("CK_Wire_DifferentTerminals", "[StartTerminalId] <> [EndTerminalId]"));
    }
}