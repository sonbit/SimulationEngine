using SimulationEngine.Domain.Converters;
using SimulationEngine.Domain.Models.Enums;
using SimulationEngine.Domain.Models.Metadata.Enums;
using System.Linq;

namespace SimulationEngine.Domain.Models.Extensions;

public static class LogicGateExtensions
{
    public static void AddPin(this LogicGate logicGate, PinRole role, Radix radix = Radix.TernaryBalanced) =>
        logicGate.Pins.Add(new Pin(radix) { Role = role, Title = role.ToString(), LogicGate = logicGate });

    public static void AddPins(this LogicGate logicGate, string heptaIndex, Radix radix = Radix.TernaryBalanced)
    {
        var arity = HeptaIndexConverter.GetArity(heptaIndex);

        logicGate.AddPin(PinRole.A, radix);
        if (arity >= 2)
            logicGate.AddPin(PinRole.B, radix);
        if (arity >= 3)
            logicGate.AddPin(PinRole.C, radix);
        if (arity == 4)
            logicGate.AddPin(PinRole.D, radix);
        logicGate.AddPin(PinRole.Q, radix);
    }

    public static int GetPinMask(this LogicGate logicGate)
    {
        return logicGate.Pins.Aggregate(0, (mask, pin) => mask | pin.Role switch
        {
            PinRole.A => 1,
            PinRole.B => 2,
            PinRole.C => 4,
            PinRole.D => 8,
            PinRole.Q => 16,
            _ => 0
        });
    }

    public static bool IsBinary(this LogicGate logicGate) => 
        logicGate.TruthTable.Metadata.Radix == Radix.Binary || logicGate.TruthTable.Metadata.Radix == Radix.BinarySigned;
}