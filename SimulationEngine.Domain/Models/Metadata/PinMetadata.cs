using SimulationEngine.Domain.Models.Metadata.Enums;

namespace SimulationEngine.Domain.Models.Metadata;

public class PinMetadata(Radix radix) : BaseRadixMetadata(radix)
{
    public PinMetadata() : this(Radix.TernaryBalanced) { }
}