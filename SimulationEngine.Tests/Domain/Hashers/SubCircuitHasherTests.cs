using SimulationEngine.Domain.Compilers;
using SimulationEngine.Domain.Hashers;

namespace SimulationEngine.Tests.Domain.Hashers;

public class SubCircuitHasherTests
{
    [Fact]
    public void Compare_DifferentReference_SameStructure_EqualHash()
    {
        var subCircuitX = ModelBuilders.CreateSubCircuit();
        var subCircuitY = ModelBuilders.CreateSubCircuit();

        var subCircuitPlacedX = SubCircuitCompiler.Compile(subCircuitX).SubCircuitPlaced;
        var subCircuitPlacedY = SubCircuitCompiler.Compile(subCircuitY).SubCircuitPlaced;

        var hashX = SubCircuitHasher.Compute(subCircuitPlacedX.SubCircuit, [.. subCircuitPlacedX.SubCircuitPlacementInfos.Select(p => p.SubCircuitPlacement)]);
        var hashY = SubCircuitHasher.Compute(subCircuitPlacedY.SubCircuit, [.. subCircuitPlacedY.SubCircuitPlacementInfos.Select(p => p.SubCircuitPlacement)]);

        Assert.Equal(hashX, hashY);
    }

    [Fact]
    public void Compare_DifferentWireOrder_EqualHash()
    {
        var subCircuitX = ModelBuilders.CreateSubCircuit();
        var subCircuitY = ModelBuilders.CreateSubCircuit(flipWireOrder: true);

        var subCircuitPlacedX = SubCircuitCompiler.Compile(subCircuitX).SubCircuitPlaced;
        var subCircuitPlacedY = SubCircuitCompiler.Compile(subCircuitY).SubCircuitPlaced;

        var hashX = SubCircuitHasher.Compute(subCircuitPlacedX.SubCircuit, [.. subCircuitPlacedX.SubCircuitPlacementInfos.Select(p => p.SubCircuitPlacement)]);
        var hashY = SubCircuitHasher.Compute(subCircuitPlacedY.SubCircuit, [.. subCircuitPlacedY.SubCircuitPlacementInfos.Select(p => p.SubCircuitPlacement)]);

        Assert.Equal(hashX, hashY);
    }

    [Fact]
    public void Compare_HeptaIndexChange_NotEqualHash()
    {
        var subCircuitX = ModelBuilders.CreateSubCircuit();
        var subCircuitY = ModelBuilders.CreateSubCircuit();

        subCircuitY.LogicGates[0].TruthTable.HeptaIndex = "000";

        var subCircuitPlacedX = SubCircuitCompiler.Compile(subCircuitX).SubCircuitPlaced;
        var subCircuitPlacedY = SubCircuitCompiler.Compile(subCircuitY).SubCircuitPlaced;

        var hashX = SubCircuitHasher.Compute(subCircuitPlacedX.SubCircuit, [.. subCircuitPlacedX.SubCircuitPlacementInfos.Select(p => p.SubCircuitPlacement)]);
        var hashY = SubCircuitHasher.Compute(subCircuitPlacedY.SubCircuit, [.. subCircuitPlacedY.SubCircuitPlacementInfos.Select(p => p.SubCircuitPlacement)]);

        Assert.NotEqual(hashX, hashY);
    }

    [Fact]
    public void Compare_PortTitleChange_NotEqualHash()
    {
        var subCircuitX = ModelBuilders.CreateSubCircuit();
        var subCircuitY = ModelBuilders.CreateSubCircuit();

        subCircuitY.Ports[0].Title = "renamed_input";

        var subCircuitPlacedX = SubCircuitCompiler.Compile(subCircuitX).SubCircuitPlaced;
        var subCircuitPlacedY = SubCircuitCompiler.Compile(subCircuitY).SubCircuitPlaced;

        var hashX = SubCircuitHasher.Compute(subCircuitPlacedX.SubCircuit, [.. subCircuitPlacedX.SubCircuitPlacementInfos.Select(p => p.SubCircuitPlacement)]);
        var hashY = SubCircuitHasher.Compute(subCircuitPlacedY.SubCircuit, [.. subCircuitPlacedY.SubCircuitPlacementInfos.Select(p => p.SubCircuitPlacement)]);

        Assert.NotEqual(hashX, hashY);
    }

    [Fact]
    public void Compare_WireChange_NotEqualHash()
    {
        var subCircuitX = ModelBuilders.CreateSubCircuit();
        var subCircuitY = ModelBuilders.CreateSubCircuit();

        subCircuitY.Wires.RemoveAt(1);

        var subCircuitPlacedX = SubCircuitCompiler.Compile(subCircuitX).SubCircuitPlaced;
        var subCircuitPlacedY = SubCircuitCompiler.Compile(subCircuitY).SubCircuitPlaced;

        var hashX = SubCircuitHasher.Compute(subCircuitPlacedX.SubCircuit, [.. subCircuitPlacedX.SubCircuitPlacementInfos.Select(p => p.SubCircuitPlacement)]);
        var hashY = SubCircuitHasher.Compute(subCircuitPlacedY.SubCircuit, [.. subCircuitPlacedY.SubCircuitPlacementInfos.Select(p => p.SubCircuitPlacement)]);

        Assert.NotEqual(hashX, hashY);
    }
}