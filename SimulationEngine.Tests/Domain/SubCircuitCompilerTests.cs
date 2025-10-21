using SimulationEngine.Designs.Subcircuits.Multiplexers;
using SimulationEngine.Domain.Compilers;

namespace SimulationEngine.Tests.Domain;

public sealed class SubcircuitCompilerTests
{
    [Fact]
    public void Compile_CreatesEqualHashes()
    {
        var subcircuitX = ModelBuilders.CreateSubcircuit();
        var subcircuitY = ModelBuilders.CreateSubcircuit();

        var placedX = SubcircuitCompiler.Compile(subcircuitX).Placed;
        var placedY = SubcircuitCompiler.Compile(subcircuitY).Placed;

        Assert.Equal(placedX.Template.Hash, placedY.Template.Hash);
    }

    [Fact]
    public void Compile_CreatesStableHashes()
    {
        var mux = new MUX();

        var closure = SubcircuitCompiler.Compile(mux);

        Assert.NotNull(closure.Placed);
        Assert.False(string.IsNullOrWhiteSpace(closure.Placed.Template.Hash));
        Assert.NotEmpty(closure.PlacedByHash);

        var childTemplateHashes = closure.Placed.PlacementInfos
            .Select(subcircuitPlacementInfo => subcircuitPlacementInfo.ChildTemplateHash).ToList();

        Assert.Equal(mux.Subcircuits.Count, childTemplateHashes.Count);
        Assert.Single(childTemplateHashes.Distinct(StringComparer.Ordinal));
    }
}