using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Enums;
using SimulationEngine.Domain.Utils;

namespace SimulationEngine.Domain.Extensions;

public static class LogicGateExtensions
{
    public static void AddPin(this LogicGate logicGate, PinRole role) =>
        logicGate.Pins.Add(new Pin { Role = role, Title = role.ToString(), LogicGate = logicGate });

    public static void AddPins(this LogicGate logicGate, string heptaIndex)
    {
        var arity = HeptaIndexConverter.GetArity(heptaIndex);

        logicGate.AddPin(PinRole.A);
        if (arity >= 2)
            logicGate.AddPin(PinRole.B);
        if (arity >= 3)
            logicGate.AddPin(PinRole.C);
        if (arity == 4)
            logicGate.AddPin(PinRole.D);
        logicGate.AddPin(PinRole.Q);
    }
}
