using SimulationEngine.Domain.Extensions;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Enums;

namespace SimulationEngine.Tests;

public static class ModelBuilders
{
    public static SubCircuit CreateSubCircuit(string title = "Id", string truthTable = "20K")
    {
        var subCircuit = new SubCircuit { Title = title };
        subCircuit.AddPorts([(nameof(PortRole.In0), PortRole.In0), (nameof(PortRole.Out0), PortRole.Out0)]);

        var logicGate = subCircuit.AddLogicGate(truthTable);

        subCircuit.AddWires([
            (subCircuit.Ports[0], logicGate.A),
            (logicGate.Q, subCircuit.Ports[1])]);

        return subCircuit;
    }

    public static SubCircuit CreateSubCircuitWithChild(string parentTitle = "Parent", string truthTable = "20K")
    {
        var subCircuit = new SubCircuit { Title = parentTitle };
        subCircuit.AddPorts([(nameof(PortRole.In0), PortRole.In0), (nameof(PortRole.Out0), PortRole.Out0)]);

        var subCircuitChild = CreateSubCircuit("Child");
        subCircuit.SubCircuits.Add(subCircuitChild);

        var logicGate = subCircuit.AddLogicGate(truthTable);

        subCircuit.AddWires([
            (subCircuit.Ports[0], subCircuitChild.Ports[0]),
            (subCircuitChild.Ports[1], logicGate.A),
            (logicGate.Q, subCircuit.Ports[1])]);

        return subCircuit;
    }
}