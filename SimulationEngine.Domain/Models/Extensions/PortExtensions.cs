using SimulationEngine.Domain.Models.Enums;
using SimulationEngine.Domain.Models.Metadata.Enums;
using System;

namespace SimulationEngine.Domain.Models.Extensions;

public static class PortExtensions
{
    public static Radix GetRadix(this Port port) =>
        port.PortMetadata.Radix;

    public static bool IsBinary(this Port port) => 
        port.PortMetadata.Radix == Radix.Binary || port.PortMetadata.Radix == Radix.BinarySigned;

    public static bool IsInput(this Port port) => 
        port.Direction == PortDirection.Input;

    public static bool IsOutput(this Port port) => 
        port.Direction == PortDirection.Output;

    public static byte ToByte(this Port port, char value) => port.PortMetadata.Radix switch
    {
        Radix.Binary or Radix.BinarySigned => value switch
        {
            '1' => 2,
            '0' => 0,
            _ => throw new InvalidOperationException($"Invalid binary value '{value}' for port {port.Title}"),
        },
        Radix.TernaryBalanced => value switch
        {
            '+' => 2,
            '0' => 1,
            '-' => 0,
            _ => throw new InvalidOperationException($"Invalid balanced ternary value '{value}' for port {port.Title}"),
        },
        Radix.TernaryUnbalanced => value switch
        {
            '2' => 2,
            '1' => 1,
            '0' => 0,
            _ => throw new InvalidOperationException($"Invalid unbalanced ternary value '{value}' for port {port.Title}"),
        },
        _ => throw new InvalidOperationException($"Unsupported radix {port.PortMetadata.Radix} for port {port.Title}"),
    };

    public static char ToChar(this Port port, byte value) => port.PortMetadata.Radix switch
    {
        Radix.Binary or Radix.BinarySigned => value switch
        {
            2 => '1',
            1 => '0',
            0 => '0',
            _ => throw new InvalidOperationException($"Invalid binary value '{value}' for port {port.Title}"),
        },
        Radix.TernaryBalanced => value switch
        {
            2 => '+',
            1 => '0',
            0 => '-',
            _ => throw new InvalidOperationException($"Invalid balanced ternary value '{value}' for port {port.Title}"),
        },
        Radix.TernaryUnbalanced => value switch
        {
            2 => '2',
            1 => '1',
            0 => '0',
            _ => throw new InvalidOperationException($"Invalid unbalanced ternary value '{value}' for port {port.Title}"),
        },
        _ => throw new InvalidOperationException($"Unsupported radix {port.PortMetadata.Radix} for port {port.Title}"),
    };
}