using SimulationEngine.Domain.Compilers;
using SimulationEngine.Domain.Hashers;

namespace SimulationEngine.Tests.Domain;

public class SubcircuitHasherTests
{
    [Fact]
    public void Compare_DifferentReference_SameStructure_EqualHash()
    {
        var subcircuitX = ModelBuilders.CreateSubcircuit();
        var subcircuitY = ModelBuilders.CreateSubcircuit();

        var placedX = SubcircuitCompiler.Compile(subcircuitX).Placed;
        var placedY = SubcircuitCompiler.Compile(subcircuitY).Placed;

        var hashX = SubcircuitHasher.Compute(placedX.Template, [.. placedX.PlacementInfos.Select(p => p.Placement)]);
        var hashY = SubcircuitHasher.Compute(placedY.Template, [.. placedY.PlacementInfos.Select(p => p.Placement)]);

        Assert.Equal(hashX, hashY);
    }

    [Fact]
    public void Compare_DifferentWireOrder_EqualHash()
    {
        var subcircuitX = ModelBuilders.CreateSubcircuit();
        var subcircuitY = ModelBuilders.CreateSubcircuit(flipWireOrder: true);

        var placedX = SubcircuitCompiler.Compile(subcircuitX).Placed;
        var placedY = SubcircuitCompiler.Compile(subcircuitY).Placed;

        var hashX = SubcircuitHasher.Compute(placedX.Template, [.. placedX.PlacementInfos.Select(p => p.Placement)]);
        var hashY = SubcircuitHasher.Compute(placedY.Template, [.. placedY.PlacementInfos.Select(p => p.Placement)]);

        Assert.Equal(hashX, hashY);
    }

    [Fact]
    public void Compare_HeptaIndexChange_NotEqualHash()
    {
        var subcircuitX = ModelBuilders.CreateSubcircuit();
        var subcircuitY = ModelBuilders.CreateSubcircuit();

        subcircuitY.LogicGates[0].TruthTable.HeptaIndex = "000";

        var placedX = SubcircuitCompiler.Compile(subcircuitX).Placed;
        var placedY = SubcircuitCompiler.Compile(subcircuitY).Placed;

        var hashX = SubcircuitHasher.Compute(placedX.Template, [.. placedX.PlacementInfos.Select(p => p.Placement)]);
        var hashY = SubcircuitHasher.Compute(placedY.Template, [.. placedY.PlacementInfos.Select(p => p.Placement)]);

        Assert.NotEqual(hashX, hashY);
    }

    [Fact]
    public void Compare_PortTitleChange_NotEqualHash()
    {
        var subcircuitX = ModelBuilders.CreateSubcircuit();
        var subcircuitY = ModelBuilders.CreateSubcircuit();

        subcircuitY.Ports[0].Title = "renamed_input";

        var placedX = SubcircuitCompiler.Compile(subcircuitX).Placed;
        var placedY = SubcircuitCompiler.Compile(subcircuitY).Placed;

        var hashX = SubcircuitHasher.Compute(placedX.Template, [.. placedX.PlacementInfos.Select(p => p.Placement)]);
        var hashY = SubcircuitHasher.Compute(placedY.Template, [.. placedY.PlacementInfos.Select(p => p.Placement)]);

        Assert.NotEqual(hashX, hashY);
    }

    [Fact]
    public void Compare_WireChange_NotEqualHash()
    {
        var subcircuitX = ModelBuilders.CreateSubcircuit();
        var subcircuitY = ModelBuilders.CreateSubcircuit();

        subcircuitY.Wires.RemoveAt(1);

        var placedX = SubcircuitCompiler.Compile(subcircuitX).Placed;
        var placedY = SubcircuitCompiler.Compile(subcircuitY).Placed;

        var hashX = SubcircuitHasher.Compute(placedX.Template, [.. placedX.PlacementInfos.Select(p => p.Placement)]);
        var hashY = SubcircuitHasher.Compute(placedY.Template, [.. placedY.PlacementInfos.Select(p => p.Placement)]);

        Assert.NotEqual(hashX, hashY);
    }
}