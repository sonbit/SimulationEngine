
using SimulationEngine.Application.Converters;
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

        var test = """
            0000 000
            2220 000
            0001 000
            0021 001
            0002 001
            0202 021
            0000 021
            0021 020
            0001 020
            0020 021
            0001 021
            0021 021
            0002 021
            0022 022
            0001 022
            0201 012
            0000 012
            0021 010
            0001 010
            0021 011
            0002 011
            0021 012
            2000 112
            0221 100
            0001 100
            0021 101
            0002 101
            0021 102
            0200 112
            0021 110
            0001 110
            0021 111
            0002 111
            0022 112
            0200 122
            0021 120
            0001 120
            0021 121
            0002 121
            0022 122
            2000 222
            0221 200
            0001 200
            0021 201
            0002 201
            0021 202
            0200 212
            0021 210
            0001 210
            0021 211
            0002 211
            0022 212
            0200 222
            0021 220
            0001 220
            0021 221
            0002 221
            0021 222
            0001 222
            2221 111
            0000 111
            2221 000
            0001 000
            0021 001
            0002 001
            0021 002
            0200 012
            0021 010
            0001 010
            0021 011
            0002 011
            0022 012
            0200 022
            0021 020
            0001 020
            0021 021
            0002 021
            0021 022
            2000 122
            0221 100
            0001 100
            0021 101
            0002 101
            0021 102
            0200 112
            0021 110
            0001 110
            0021 111
            0002 111
            0022 112
            0200 122
            0021 120
            0001 120
            0021 121
            0002 121
            0022 122
            2000 222
            0221 200
            0001 200
            0021 201
            """;

        var testVector = TestStringConverter.Convert(test);

        var tests = new List<(byte[] inputs, byte[] expected)>();
        foreach (var tv in testVector)
            tests.Add((tv.Inputs, tv.ExpectedOutputs));

        var output = emitter.EmitTestbench(subCircuit, tests);
        testOutputHelper.WriteLine(output);
    }

    [Fact]
    public void Test2()
    {
        var subCircuit = new BTLatch();
        var emitter = new VerilogTestbenchEmitter(new ExportOptions());

        var test = """
            00 0
            01 0
            21 1
            02 1
            22 2
            01 2
            21 1
            00 1
            20 0
            02 0
            21 1
            02 1
            22 2
            00 2
            20 0
            00 0
            """;

        var testVector = TestStringConverter.Convert(test);

        var tests = new List<(byte[] inputs, byte[] expected)>();
        foreach (var tv in testVector)
            tests.Add((tv.Inputs, tv.ExpectedOutputs));

        var output = emitter.EmitTestbench(subCircuit, tests);
        testOutputHelper.WriteLine(output);
    }
}
