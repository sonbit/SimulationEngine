using SimulationEngine.Domain.Models.Metadata.Enums;

namespace SimulationEngine.Domain.Models.Extensions;

public static class PinExtensions
{
    public static bool IsBinary(this Pin pin) => 
        pin.Metadata.Radix == Radix.Binary || pin.Metadata.Radix == Radix.BinarySigned;
}