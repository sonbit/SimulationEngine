using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Utils;

namespace SimulationEngine.Infrastructure.DataModel.Extensions;

public static class ModelBuilderExtensions
{
    public static void ApplyBaseConfiguration(this ModelBuilder modelBuilder)
    {
        var id = nameof(BaseEntity.Id);

        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            var entity = entityType.ClrType;
            if (entity is null || entityType.IsOwned() || entityType.BaseType != null) 
                continue;

            foreach (var property in entityType.GetProperties())
            {
                if (property.Name == id)
                {
                    var entityTypeBuilder = modelBuilder.Entity(entity);

                    if (entityType.FindPrimaryKey() == null)
                        entityTypeBuilder.HasKey(id);

                    entityTypeBuilder.Property(id).ValueGeneratedOnAdd();
                }
                else if (property.ClrType == typeof(string))
                {
                    property.SetValueConverter(
                        new ValueConverter<string, string>(
                            toDbValue => StringSanitizer.Sanitize(toDbValue),
                            fromDbValue => StringSanitizer.Sanitize(fromDbValue)));
                }
            }
        }
    }
}