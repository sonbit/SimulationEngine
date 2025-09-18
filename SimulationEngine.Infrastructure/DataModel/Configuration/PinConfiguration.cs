using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimulationEngine.Domain.Models;

namespace SimulationEngine.Infrastructure.DataModel.Configuration;

internal class PinConfiguration
{
    internal static void Configure(EntityTypeBuilder<Pin> entity)
    {
        entity
            .Property(pin => pin.Role)
            .HasConversion<string>()
            .HasColumnName(nameof(Pin.Role))
            .IsRequired();

        entity
            .HasOne(pin => pin.LogicGate)
            .WithMany(logicGate => logicGate.Pins)
            .HasForeignKey(pin => pin.LogicGateId);

        entity
            .HasIndex(pin => new { pin.LogicGateId, pin.Role })
            .IsUnique();
    }
}