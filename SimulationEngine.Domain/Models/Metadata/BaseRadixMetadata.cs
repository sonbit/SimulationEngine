using SimulationEngine.Domain.Models.Metadata.Enums;

namespace SimulationEngine.Domain.Models.Metadata;

public abstract class BaseRadixMetadata(Radix radix) : BaseEntity
{
    public Radix Radix { get; set; } = radix;
}