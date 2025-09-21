using SimulationEngine.Domain.Models.Enums;
using SimulationEngine.Domain.Models.Metadata.Enums;

namespace SimulationEngine.Domain.Models.Extensions;

public static class PortExtensions
{
    public static bool IsBinary(this Port port) => 
        port.PortMetadata.Radix == Radix.Binary || port.PortMetadata.Radix == Radix.BinarySigned;

    public static bool IsInput(this Port port) => 
        port.Direction == PortDirection.Input;

    public static bool IsOutput(this Port port) => 
        port.Direction == PortDirection.Output;
}