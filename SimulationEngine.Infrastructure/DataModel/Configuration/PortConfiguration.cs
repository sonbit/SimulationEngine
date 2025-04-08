using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimulationEngine.Domain.Models;

namespace SimulationEngine.Infrastructure.DataModel.Configuration
{
    internal static class PortConfiguration
    {
        internal static void Configure(EntityTypeBuilder<Port> entity)
        {
            entity
                .ToTable($"{nameof(Port).ToLower()}s")
                .HasKey(port => port.Id);

            entity
                .Property(port => port.Id)
                .ValueGeneratedOnAdd();

            entity
                .Property(port => port.Title)
                .HasMaxLength(50);

            entity
                .HasOne(port => port.Input)
                .WithMany(input => input.Ports)
                .HasForeignKey(port => port.InputId);
            
            entity
                .HasOne(port => port.Output)
                .WithMany(output => output.Ports)
                .HasForeignKey(port => port.OutputId);
        }
    }
}