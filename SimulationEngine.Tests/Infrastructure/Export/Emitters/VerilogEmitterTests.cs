using SimulationEngine.Application.Export;
using SimulationEngine.Designs.SubCircuits.Memory;
using SimulationEngine.Infrastructure.Exporters.Verilog;
using Xunit.Abstractions;

namespace SimulationEngine.Tests.Infrastructure.Export.Emitters;

public class VerilogEmitterTests(ITestOutputHelper testOutputHelper)
{
    [Fact]
    public void Test1()
    {
        var subCircuit = new RAM3();
        var emitter = new VerilogEmitter(new ExportOptions());
        var output = emitter.EmitSubCircuit(subCircuit);
        testOutputHelper.WriteLine(output);
    }
}
