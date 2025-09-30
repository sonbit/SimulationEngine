using SimulationEngine.Domain.Models.Metadata.Enums;

namespace SimulationEngine.Domain.Models.Metadata;

public class TruthTableMetadata(Radix radix) : BaseRadixMetadata(radix)
{
    public TruthTableMetadata() : this(Radix.TernaryBalanced) { }
}