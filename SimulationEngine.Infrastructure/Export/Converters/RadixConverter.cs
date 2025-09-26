using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Metadata.Enums;
using System;

namespace SimulationEngine.Infrastructure.Export.Converters;

public static class RadixConverter
{
    public static string Convert(Port port, char value) => port.PortMetadata.Radix switch
    {
        Radix.Binary or Radix.BinarySigned => $"1'b{value}",
        Radix.TernaryBalanced => value switch 
        {
            '-' => "2'b01",
            '0' => "2'b11",
            '+' => "2'b10",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, null)
        },
        Radix.TernaryUnbalanced => value switch
        {
            '0' => "2'b01",
            '1' => "2'b11",
            '2' => "2'b10",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, null)
        },
        _ => throw new ArgumentOutOfRangeException(port.Title, port.PortMetadata.Radix, null)
    };

    public static string Convert(LogicGate logicGate, byte value) => logicGate.TruthTable.Metadata.Radix switch
    {
        Radix.Binary or Radix.BinarySigned => $"1'b{value}",
        Radix.TernaryBalanced or Radix.TernaryUnbalanced => value switch
        {
            0 => "2'b01",
            1 => "2'b11",
            2 => "2'b10",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, null)
        },
        _ => throw new ArgumentOutOfRangeException(logicGate.TruthTable.HeptaIndex, logicGate.TruthTable.Metadata.Radix, null)
    };
}