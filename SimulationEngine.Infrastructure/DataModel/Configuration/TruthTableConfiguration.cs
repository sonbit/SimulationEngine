using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimulationEngine.Domain.Models;

namespace SimulationEngine.Infrastructure.DataModel.Configuration
{
    internal static class TruthTableConfiguration
    {
        private const byte MaxHeptavintimalLength = 27;
        private const byte MaxDefinitionLength = MaxHeptavintimalLength * 3;
        
        internal static void Configure(EntityTypeBuilder<TruthTable> entity)
        {
            entity
                .ToTable($"{nameof(TruthTable).ToLower()}s")
                .HasKey(truthTable => truthTable.Id);

            entity
                .Property(truthTable => truthTable.Id)
                .ValueGeneratedOnAdd();

            entity
                .Property(truthTable => truthTable.Title)
                .HasMaxLength(50);
            
            entity
                .Property(truthTable => truthTable.HeptaIndex)
                .HasMaxLength(MaxHeptavintimalLength)
                .IsRequired();

            entity
                .Property(truthTable => truthTable.Definition)
                .HasColumnType($"varbinary({MaxDefinitionLength})")
                .IsRequired();
            
            entity
                .HasMany(truthTable => truthTable.LogicGates)
                .WithOne(logicGate => logicGate.TruthTable)
                .HasForeignKey(logicGate => logicGate.TruthTableId);
        }
    }
}