using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Extensions;

namespace SimulationEngine.Tests;

public static class ModelBuilders
{
    public static Subcircuit CreateSubcircuit(string title = "Id", string truthTable = "20K", bool flipWireOrder = false)
    {
        var subcircuit = new Subcircuit { Title = title };
        subcircuit.AddInput();
        subcircuit.AddOutput();

        var logicGate = subcircuit.AddLogicGate(truthTable);

        if (!flipWireOrder)
            subcircuit.AddWires([(subcircuit.Ports[0], logicGate.A), (logicGate.Q, subcircuit.Ports[1])]);
        else 
            subcircuit.AddWires([(logicGate.Q, subcircuit.Ports[1]), (subcircuit.Ports[0], logicGate.A)]);

        return subcircuit;
    }

    public static Subcircuit CreateSubcircuitWithChild(string parentTitle = "Parent", string truthTable = "20K")
    {
        var subcircuit = new Subcircuit { Title = parentTitle };
        subcircuit.AddInput();
        subcircuit.AddOutput();

        var subcircuitChild = CreateSubcircuit("Child");
        subcircuit.Subcircuits.Add(subcircuitChild);

        var logicGate = subcircuit.AddLogicGate(truthTable);

        subcircuit.AddWires([
            (subcircuit.Ports[0], subcircuitChild.Ports[0]),
            (subcircuitChild.Ports[1], logicGate.A),
            (logicGate.Q, subcircuit.Ports[1])]);

        return subcircuit;
    }
}