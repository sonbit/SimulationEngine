using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Extensions;
using System;

namespace SimulationEngine.Infrastructure.Export.Emitters;

public static class VerilogUtils
{
    private const string LogicGateModulePrefix = "f_";
    private const string SubcircuitModulePrefix = "c_";

    public static string GetLogicGateModuleName(LogicGate logicGate, bool hasFeedbackToB = false) => 
        $"{LogicGateModulePrefix}{logicGate.TruthTable.HeptaIndex}{(hasFeedbackToB ? "_latch" : string.Empty)}";

    public static string GetPinIdentifier(Pin pin) =>
        pin.Role.ToString();

    public static string GetPortWidthAndIdentifier(Port port) =>
        $"{GetWidth(port.IsBinary())}{GetPortIdentifier(port)}";

    public static string GetPortIdentifier(Port port) =>
        $"{port.Direction.ToString().ToLowerInvariant()}_{port.Ordinal}";

    public static string GetTerminalIdentifier(Terminal terminal) => terminal switch
    {
        Pin pin => GetPinIdentifier(pin),
        Port port => GetPortIdentifier(port),
        _ => throw new ArgumentOutOfRangeException(nameof(terminal), $"Unsupported terminal type {terminal?.GetType().Name}")
    };

    public static string GetSubcircuitModuleName(Subcircuit subcircuit) => 
        $"{SubcircuitModulePrefix}{subcircuit.Title}";

    public static string GetWidth(bool isBinary) => 
        isBinary ? "" : "[1:0] ";
}
