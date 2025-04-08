using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimulationEngine.Domain.Models;

namespace SimulationEngine.Infrastructure.DataModel.Configuration
{
    internal static class LogicGateConfiguration
    {
        internal static void Configure(EntityTypeBuilder<LogicGate> entity)
        {
            entity
                .ToTable($"{nameof(LogicGate).ToLower()}s")
                .HasKey(logicGate => logicGate.Id);

            entity
                .Property(logicGate => logicGate.Id)
                .ValueGeneratedOnAdd();

            entity
                .HasOne(logicGate => logicGate.PortA)
                .WithOne()
                .HasForeignKey<LogicGate>(port => port.PortAId);
            
            entity
                .HasOne(logicGate => logicGate.PortB)
                .WithOne()
                .HasForeignKey<LogicGate>(port => port.PortBId);
            
            entity
                .HasOne(logicGate => logicGate.PortC)
                .WithOne()
                .HasForeignKey<LogicGate>(port => port.PortCId);
            
            entity
                .HasOne(logicGate => logicGate.PortD)
                .WithOne()
                .HasForeignKey<LogicGate>(port => port.PortDId);
            
            entity
                .HasOne(logicGate => logicGate.PortQ)
                .WithOne()
                .HasForeignKey<LogicGate>(port => port.PortQId);
            
            entity
                .HasOne(logicGate => logicGate.TruthTable)
                .WithMany(truthTable => truthTable.LogicGates)
                .HasForeignKey(logicGate => logicGate.TruthTableId)
                .IsRequired();
            
            entity
                .HasOne(logicGate => logicGate.SubCircuit)
                .WithMany(subCircuit => subCircuit.LogicGates)
                .HasForeignKey(logicGate => logicGate.SubCircuitId);
        }
    }
}