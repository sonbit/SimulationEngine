using SimulationEngine.Domain.Models.Metadata.Enums;

namespace SimulationEngine.Domain.Models.Metadata;

public class LogicGateMetadata : BaseMetadata
{
    public LogicGateMetadata() { }

    public LogicGateMetadata(Radix radix) => Radix = radix;

    public Radix Radix { get; set; } = Radix.TernaryBalanced;
}