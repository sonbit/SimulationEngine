using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimulationEngine.Domain.Models;

namespace SimulationEngine.Infrastructure.DataModel.Configuration
{
    internal static class WireConfiguration
    {
        internal static void Configure(EntityTypeBuilder<Wire> entity)
        {
            entity
                .ToTable($"{nameof(Wire).ToLower()}s")
                .HasKey(wire => wire.Id);

            entity
                .Property(wire => wire.Id)
                .ValueGeneratedOnAdd();

            entity
                .HasOne(wire => wire.StartPort)
                .WithMany()
                .HasForeignKey(wire => wire.StartPortId);

            entity
                .HasOne(wire => wire.EndPort)
                .WithOne()
                .HasForeignKey<Wire>(wire => wire.EndPortId);
            
            entity
                .HasOne(wire => wire.SubCircuit)
                .WithMany(subCircuit => subCircuit.Wires)
                .HasForeignKey(wire => wire.SubCircuitId);
        }
    }
}