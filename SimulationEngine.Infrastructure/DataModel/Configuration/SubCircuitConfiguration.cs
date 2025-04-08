using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimulationEngine.Domain.Models;

namespace SimulationEngine.Infrastructure.DataModel.Configuration
{
    internal static class SubCircuitConfiguration
    {
        internal static void Configure(EntityTypeBuilder<SubCircuit> entity)
        {
            entity
                .ToTable($"{nameof(SubCircuit).ToLower()}s")
                .HasKey(subCircuit => subCircuit.Id);

            entity
                .Property(subCircuit => subCircuit.Id)
                .ValueGeneratedOnAdd();

            entity
                .Property(subCircuit => subCircuit.Title)
                .HasMaxLength(50);
            
            entity
                .HasOne(subCircuit => subCircuit.Parent)
                .WithMany(subCircuit => subCircuit.Children)
                .HasForeignKey(subCircuit => subCircuit.ParentId);
            
            entity
                .HasMany(subCircuit => subCircuit.Children)
                .WithOne(subCircuit => subCircuit.Parent)
                .HasForeignKey(subCircuit => subCircuit.ParentId);
            
            entity
                .HasMany(subCircuit => subCircuit.Inputs)
                .WithOne(input => input.SubCircuit)
                .HasForeignKey(input => input.SubCircuitId);
            
            entity
                .HasMany(subCircuit => subCircuit.LogicGates)
                .WithOne(logicGate => logicGate.SubCircuit)
                .HasForeignKey(logicGate => logicGate.SubCircuitId);
            
            entity
                .HasMany(subCircuit => subCircuit.Outputs)
                .WithOne(output => output.SubCircuit)
                .HasForeignKey(output => output.SubCircuitId);
            
            entity
                .HasMany(subCircuit => subCircuit.Wires)
                .WithOne(wire => wire.SubCircuit)
                .HasForeignKey(wire => wire.SubCircuitId);
        }
    }
}