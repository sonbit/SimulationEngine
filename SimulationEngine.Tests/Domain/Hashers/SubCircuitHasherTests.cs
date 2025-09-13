using SimulationEngine.Domain.Extensions;
using SimulationEngine.Domain.Hashers;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Enums;

namespace SimulationEngine.Tests.Domain.Hashers;

public class SubCircuitHasherTests
{
    [Fact]
    public void Compare_DifferentReference_SameStructure_EqualHash()
    {
        var subCircuitX = ModelBuilders.CreateSubCircuit();
        var subCircuitY = ModelBuilders.CreateSubCircuit();

        var hashX = SubCircuitHasher.ComputeAndAssignHash(subCircuitX);
        var hashY = SubCircuitHasher.ComputeAndAssignHash(subCircuitY);

        Assert.Equal(hashX, hashY);
    }

    [Fact]
    public void Compare_DifferentWireOrder_EqualHash()
    {
        var subCircuitX = new SubCircuit { Title = "SubCircuitX" };
        subCircuitX.AddPorts([(nameof(PortRole.In0), PortRole.In0), (nameof(PortRole.Out0), PortRole.Out0)]);

        var subCircuitChild = ModelBuilders.CreateSubCircuit("SubCircuitChild");
        subCircuitX.SubCircuits.Add(subCircuitChild);

        var logicGate = subCircuitX.AddLogicGate("PPP");

        subCircuitX.AddWires([
            (logicGate.Q, subCircuitX.Ports[1]),
            (subCircuitX.Ports[0], subCircuitChild.Ports[0]),
            (subCircuitChild.Ports[1], logicGate.A)]);

        var hashX = SubCircuitHasher.ComputeAndAssignHash(subCircuitX);
        var hashY = SubCircuitHasher.ComputeAndAssignHash(ModelBuilders.CreateSubCircuitWithChild("SubCircuitY"));

        Assert.Equal(hashX, hashY);
    }

    [Fact]
    public void Compare_HeptaIndexChange_UnequalHash()
    {
        var subCircuitX = ModelBuilders.CreateSubCircuit();
        var subCircuitY = ModelBuilders.CreateSubCircuit();

        subCircuitY.LogicGates[0].TruthTable.HeptaIndex = "000";

        var hashX = SubCircuitHasher.ComputeAndAssignHash(subCircuitX);
        var hashY = SubCircuitHasher.ComputeAndAssignHash(subCircuitY);

        Assert.NotEqual(hashX, hashY);
    }

    [Fact]
    public void Compare_PortTitleChange_UnequalHash()
    {
        var subCircuitX = ModelBuilders.CreateSubCircuit();
        var subCircuitY = ModelBuilders.CreateSubCircuit();

        subCircuitY.Ports[0].Title = "renamed_input";

        var hashX = SubCircuitHasher.ComputeAndAssignHash(subCircuitX);
        var hashY = SubCircuitHasher.ComputeAndAssignHash(subCircuitY);

        Assert.NotEqual(hashX, hashY);
    }

    [Fact]
    public void Compare_WireChange_UnequalHash()
    {
        var subCircuitX = ModelBuilders.CreateSubCircuit();
        var subCircuitY = ModelBuilders.CreateSubCircuit();

        subCircuitY.Wires.RemoveAt(1);

        var hashX = SubCircuitHasher.ComputeAndAssignHash(subCircuitX);
        var hashY = SubCircuitHasher.ComputeAndAssignHash(subCircuitY);

        Assert.NotEqual(hashX, hashY);
    }


}