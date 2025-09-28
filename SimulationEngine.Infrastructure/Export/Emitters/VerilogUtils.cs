using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Extensions;

namespace SimulationEngine.Infrastructure.Export.Emitters;

public static class VerilogUtils
{
    private const string LogicGateModulePrefix = "f_";
    private const string SubCircuitModulePrefix = "c_";

    public static string GetLogicGateModuleName(LogicGate logicGate) => 
        $"{LogicGateModulePrefix}{logicGate.TruthTable.HeptaIndex}";

    public static string GetPortWidthAndTitle(Port port) =>
        $"{GetWidth(port.IsBinary())}{port.Title}";

    public static string GetSubCircuitModuleName(SubCircuit subCircuit) => 
        $"{SubCircuitModulePrefix}{subCircuit.Title}";

    public static string GetWidth(bool isBinary) => 
        isBinary ? "" : "[1:0] ";
}