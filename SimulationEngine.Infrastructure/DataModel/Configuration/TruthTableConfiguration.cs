using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimulationEngine.Domain.Models;

namespace SimulationEngine.Infrastructure.DataModel.Configuration;

internal static class TruthTableConfiguration
{
    internal static void Configure(EntityTypeBuilder<TruthTable> entity)
    {
        entity
            .Property(truthTable => truthTable.Title)
            .HasMaxLength(100);

        entity
            .Property(truthTable => truthTable.HeptaIndex)
            .IsRequired()
            .HasMaxLength(81)
            .IsUnicode(false);

        entity
            .HasMany(truthTable => truthTable.LogicGates)
            .WithOne(logicGate => logicGate.TruthTable)
            .HasForeignKey(logicGate => logicGate.TruthTableId);

        //entity
        //    .HasIndex(truthTable => truthTable.HeptaIndex)
        //    .IsUnique();

        entity
            .ToTable(table => table.HasCheckConstraint("CK_TruthTable_HeptaIndexLength", "length([HeptaIndex]) IN (1,3,9,27,81)"));
    }
}