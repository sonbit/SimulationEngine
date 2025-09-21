using SimulationEngine.Designs.SubCircuits.Memory;
using SimulationEngine.Infrastructure.Export.Emitters;
using Xunit.Abstractions;

namespace SimulationEngine.Tests.Infrastructure.Export.Emitters;

public class Basys3EmitterTests(ITestOutputHelper testOutputHelper)
{
    [Fact]
    public void Test1()
    {
        var subCircuit = new RAM3();
        var emitter = new Basys3Emitter();
        var output = emitter.EmitSubCircuit(subCircuit);
        testOutputHelper.WriteLine(output);
    }
}
