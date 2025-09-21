using SimulationEngine.Domain.Models.Metadata.Enums;

namespace SimulationEngine.Domain.Models.Metadata;

public class PortMetadata : BaseEntity
{
    public PortMetadata() { }

    public PortMetadata(Radix radix) => Radix = radix;

    public Radix Radix { get; set; } = Radix.TernaryBalanced;
}