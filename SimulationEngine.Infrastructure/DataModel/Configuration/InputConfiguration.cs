using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimulationEngine.Domain.Models;

namespace SimulationEngine.Infrastructure.DataModel.Configuration
{
    internal static class InputConfiguration
    {
        internal static void Configure(EntityTypeBuilder<Input> entity)
        {
            entity
                .ToTable($"{nameof(Input).ToLower()}s")
                .HasKey(input => input.Id);

            entity
                .Property(input => input.Id)
                .ValueGeneratedOnAdd();

            entity
                .HasMany(input => input.Ports)
                .WithOne(port => port.Input)
                .HasForeignKey(port => port.InputId);
            
            entity
                .HasOne(input => input.SubCircuit)
                .WithMany(subCircuit => subCircuit.Inputs)
                .HasForeignKey(input => input.SubCircuitId);
        }
    }
}