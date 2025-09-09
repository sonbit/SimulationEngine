using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimulationEngine.Domain.Models;

namespace SimulationEngine.Infrastructure.DataModel.Configuration;

internal static class LogicGateConfiguration
{
    internal static void Configure(EntityTypeBuilder<LogicGate> entity)
    {
        entity
            .Property(logicGate => logicGate.Hash)
            .HasMaxLength(64);

        entity
            .HasOne(logicGate => logicGate.SubCircuit)
            .WithMany(subCircuit => subCircuit.LogicGates)
            .HasForeignKey(logicGate => logicGate.SubCircuitId);

        entity
            .HasOne(logicGate => logicGate.TruthTable)
            .WithMany(truthTable => truthTable.LogicGates)
            .HasForeignKey(logicGate => logicGate.TruthTableId);

        entity
            .HasMany(logicGate => logicGate.Pins)
            .WithOne(pin => pin.LogicGate)
            .HasForeignKey(pin => pin.LogicGateId);

        entity
            .HasIndex(logicGate => logicGate.TruthTableId);

        entity
            .HasIndex(logicGate => logicGate.Hash)
            .IsUnique();
    }
}