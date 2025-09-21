using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Placements;
using System;

namespace SimulationEngine.Domain.Encoders;

public static class TerminalEncoder
{
    private const string LogicGatePin = $"{nameof(LogicGate)}{nameof(Port)}";
    private const char Separator = '|';
    private const string TopPort = $"Top{nameof(Port)}";

    public static string Encode(Terminal terminal) => terminal switch
    {
        Port port => $"{TopPort}{Separator}{port.Name}",
        Pin pin => $"{LogicGatePin}{Separator}{pin.Role}",
        PortPlacement portPlacement => $"{nameof(PortPlacement)}{Separator}{portPlacement.IsInput}{Separator}{portPlacement.IndexWithinChild}",
        _ => throw new NotSupportedException("Unknwon terminal type")
    };
}