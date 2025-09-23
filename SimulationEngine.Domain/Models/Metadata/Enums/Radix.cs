using System.ComponentModel;

namespace SimulationEngine.Domain.Models.Metadata.Enums;

public enum Radix
{
    [Description("Binary")] Binary,
    [Description("Signed Binary")] BinarySigned,
    [Description("Unbalanced Ternary")] TernaryUnbalanced,
    [Description("Balanced Ternary")] TernaryBalanced
}