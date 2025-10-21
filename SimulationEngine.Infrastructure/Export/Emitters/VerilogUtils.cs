using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Extensions;

namespace SimulationEngine.Infrastructure.Export.Emitters;

public static class VerilogUtils
{
    private const string LogicGateModulePrefix = "f_";
    private const string SubcircuitModulePrefix = "c_";

    public static string GetLogicGateModuleName(LogicGate logicGate) => 
        $"{LogicGateModulePrefix}{logicGate.TruthTable.HeptaIndex}";

    public static string GetPortWidthAndTitle(Port port) =>
        $"{GetWidth(port.IsBinary())}{port.Title}";

    public static string GetSubcircuitModuleName(Subcircuit subcircuit) => 
        $"{SubcircuitModulePrefix}{subcircuit.Title}";

    public static string GetWidth(bool isBinary) => 
        isBinary ? "" : "[1:0] ";
}