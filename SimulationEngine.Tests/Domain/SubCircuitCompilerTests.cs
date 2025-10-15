using SimulationEngine.Designs.SubCircuits.Multiplexers;
using SimulationEngine.Domain.Compilers;

namespace SimulationEngine.Tests.Domain;

public sealed class SubCircuitCompilerTests
{
    [Fact]
    public void Compile_CreatesEqualHashes()
    {
        var subCircuitX = ModelBuilders.CreateSubCircuit();
        var subCircuitY = ModelBuilders.CreateSubCircuit();

        var subCircuitPlacedX = SubCircuitCompiler.Compile(subCircuitX).SubCircuitPlaced;
        var subCircuitPlacedY = SubCircuitCompiler.Compile(subCircuitY).SubCircuitPlaced;

        Assert.Equal(subCircuitPlacedX.SubCircuit.Hash, subCircuitPlacedY.SubCircuit.Hash);
    }

    [Fact]
    public void Compile_CreatesStableHashes()
    {
        var mux = new MUX();

        var subCircuitCLosure = SubCircuitCompiler.Compile(mux);

        Assert.NotNull(subCircuitCLosure.SubCircuitPlaced);
        Assert.False(string.IsNullOrWhiteSpace(subCircuitCLosure.SubCircuitPlaced.SubCircuit.Hash));
        Assert.NotEmpty(subCircuitCLosure.MapByHash);

        var childSubCircuitHashes = subCircuitCLosure.SubCircuitPlaced.SubCircuitPlacementInfos
            .Select(subCircuitPlacementInfo => subCircuitPlacementInfo.ChildSubCircuitHash).ToList();

        Assert.Equal(mux.SubCircuits.Count, childSubCircuitHashes.Count);
        Assert.Single(childSubCircuitHashes.Distinct(StringComparer.Ordinal));
    }
}