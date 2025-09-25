
using SimulationEngine.Application.Export;
using SimulationEngine.Designs.SubCircuits.Latches;
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

        var testString = """
            000- ---
            111- ---
            0000 ---
            0010 --0
            000+ --0
            010+ -+0
            000- -+0
            0010 -+-
            0000 -+-
            001- -+0
            0000 -+0
            0010 -+0
            000+ -+0
            001+ -++
            0000 -++
            0100 -0+
            000- -0+
            0010 -0-
            0000 -0-
            0010 -00
            000+ -00
            0010 -0+
            100- 00+
            0110 0--
            0000 0--
            0010 0-0
            000+ 0-0
            0010 0-+
            010- 00+
            0010 00-
            0000 00-
            0010 000
            000+ 000
            001+ 00+
            010- 0++
            0010 0+-
            0000 0+-
            0010 0+0
            000+ 0+0
            001+ 0++
            100- +++
            0110 +--
            0000 +--
            0010 +-0
            000+ +-0
            0010 +-+
            010- +0+
            0010 +0-
            0000 +0-
            0010 +00
            000+ +00
            001+ +0+
            010- +++
            0010 ++-
            0000 ++-
            0010 ++0
            000+ ++0
            0010 +++
            0000 +++
            1110 000
            000- 000
            1110 ---
            0000 ---
            0010 --0
            000+ --0
            0010 --+
            010- -0+
            0010 -0-
            0000 -0-
            0010 -00
            000+ -00
            001+ -0+
            010- -++
            0010 -+-
            0000 -+-
            0010 -+0
            000+ -+0
            0010 -++
            100- 0++
            0110 0--
            0000 0--
            0010 0-0
            000+ 0-0
            0010 0-+
            010- 00+
            0010 00-
            0000 00-
            0010 000
            000+ 000
            001+ 00+
            010- 0++
            0010 0+-
            0000 0+-
            0010 0+0
            000+ 0+0
            001+ 0++
            100- +++
            0110 +--
            0000 +--
            0010 +-0
        """;

        var output = emitter.EmitTestbench(subCircuit, testString);
        testOutputHelper.WriteLine(output);
    }

    [Fact]
    public void Test2()
    {
        var subCircuit = new BTLatch();
        var emitter = new VerilogTestbenchEmitter(new ExportOptions());

        var testString = """
            0- -
            00 -
            10 0
            0+ 0
            1+ +
            00 +
            10 0
            0- 0
            1- -
            0+ -
            10 0
            0+ 0
            1+ +
            0- +
            1- -
            0- -
        """;

        var output = emitter.EmitTestbench(subCircuit, testString);
        testOutputHelper.WriteLine(output);
    }
}
