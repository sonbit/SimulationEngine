using SimulationEngine.Designs.SubCircuits.Latches;
using Xunit.Abstractions;

namespace SimulationEngine.Tests.Designs.SubCircuits;

public class LatchTests(ITestOutputHelper output) : BaseDesignTest(output)
{
    [Fact]
    public void _2Latch2_Validate()
    {
        RunTest(new _2Latch2(), """
            000 00
            200 00
            001 00
            201 01
            000 01
            202 02
            000 02
            210 10
            000 10
            211 11
            000 11
            212 12
            000 12
            220 20
            000 20
            221 21
            000 21
            222 22
            000 22
            200 00
            000 00
            """);
    }

    [Fact]
    public void BTLatch_Validate()
    {
        RunTest(new BTLatch(), """
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
            """);
    }

    [Fact]
    public void DLatchEdge_Validate()
    {
        RunTest(new DLatchEdge(), """
            00 0
            20 0
            01 0
            02 0
            00 0
            01 0
            21 1
            02 1
            22 2
            01 2
            21 1
            00 1
            20 0
            00 0
            """);
    }

    [Fact]
    public void TFlipFlop_Validate()
    {
        RunTest(new TFlipFlop(), """
            00 0
            20 0
            01 0
            21 1
            02 1
            22 2
            00 2
            20 0
            01 0
            21 1
            02 1
            22 2
            00 2
            20 0
            01 0
            21 1
            02 1
            22 2
            00 2
            20 0
            00 0
            """);
    }
}
