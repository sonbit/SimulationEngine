using SimulationEngine.Domain.Models.Metadata.Enums;

namespace SimulationEngine.Domain.Models.Metadata;

public class TruthTableMetadata : BaseEntity
{
    public TruthTableMetadata() { }

    public TruthTableMetadata(Radix radix) => Radix = radix;

    public Radix Radix { get; set; } = Radix.TernaryBalanced;
}