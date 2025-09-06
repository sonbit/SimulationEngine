using Microsoft.EntityFrameworkCore;
using SimulationEngine.Domain.Models;

namespace SimulationEngine.Infrastructure.DataModel.Extensions;

public static class ModelBuilderExtensions
{
    public static void ApplyBaseConfiguration(this ModelBuilder modelBuilder)
    {
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            var entity = entityType.ClrType;
            if (entity is null || entityType.IsOwned() || entityType.BaseType != null) 
                continue;

            var idPropertyString = nameof(BaseEntity.Id);
            if (entityType.FindProperty(idPropertyString) != null)
            {
                var entityTypeBuilder = modelBuilder.Entity(entity);

                if (entityType.FindPrimaryKey() == null)
                    entityTypeBuilder.HasKey(idPropertyString);

                entityTypeBuilder.Property(idPropertyString).ValueGeneratedOnAdd();
            }
        }
    }
}
