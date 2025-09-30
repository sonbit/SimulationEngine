using SimulationEngine.Domain.Models.Metadata.Enums;

namespace SimulationEngine.Domain.Models.Metadata;

public class PortMetadata(Radix radix) : BaseRadixMetadata(radix)
{
    public PortMetadata() : this(Radix.TernaryBalanced) { }
}