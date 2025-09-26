
using SimulationEngine.Application.Export;
using SimulationEngine.Designs.REBEL2.ALU;
using SimulationEngine.Designs.REBEL2.Decode;
using SimulationEngine.Designs.REBEL2.Fetch;
using SimulationEngine.Designs.SubCircuits.Memory;
using SimulationEngine.Infrastructure.Export.Emitters;
using Xunit.Abstractions;

namespace SimulationEngine.Tests.Infrastructure.Export.Emitters;

public class VerilogTestbenchEmitterTests(ITestOutputHelper testOutputHelper)
{
    [Fact]
    public void Test1()
    {
        var subCircuit = new RAM3();
        var emitter = new VerilogTestbenchEmitter(new ExportOptions());
        var output = emitter.EmitTestbench(subCircuit, subCircuit.GetTestString());
        testOutputHelper.WriteLine(output);
    }

    [Fact]
    public void Test2()
    {
        var subCircuit = new Register9();
        var emitter = new VerilogTestbenchEmitter(new ExportOptions());
        var output = emitter.EmitTestbench(subCircuit, subCircuit.GetTestString());
        testOutputHelper.WriteLine(output);
    }

    [Fact]
    public void Test3()
    {
        var subCircuit = new ALU2();
        var emitter = new VerilogTestbenchEmitter(new ExportOptions());
        var output = emitter.EmitTestbench(subCircuit, subCircuit.GetTestString());
        testOutputHelper.WriteLine(output);
    }

    [Fact]
    public void Test4()
    {
        var subCircuit = new Decode();
        var emitter = new VerilogTestbenchEmitter(new ExportOptions());
        var output = emitter.EmitTestbench(subCircuit, subCircuit.GetTestString());
        testOutputHelper.WriteLine(output);
    }

    [Fact]
    public void Test5()
    {
        var subCircuit = new Fetch();
        var emitter = new VerilogTestbenchEmitter(new ExportOptions());
        var output = emitter.EmitTestbench(subCircuit, subCircuit.GetTestString());
        testOutputHelper.WriteLine(output);
    }
}
