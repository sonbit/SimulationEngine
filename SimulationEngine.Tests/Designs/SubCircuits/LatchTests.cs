using SimulationEngine.Designs.SubCircuits.Latches;
using Xunit.Abstractions;

namespace SimulationEngine.Tests.Designs.SubCircuits;

public class LatchTests(ITestOutputHelper testOutputHelper) : BaseDesignTest(testOutputHelper)
{
    [Fact]
    public void _2Latch2_Validate() => TestSimulatation(new _2Latch2());

    [Fact]
    public void BTLatch_Validate() => TestSimulatation(new BTLatch());

    [Fact]
    public void DLatchEdge_Validate() => TestSimulatation(new DLatchEdge());

    [Fact]
    public void SRLatch_Validate() => TestSimulatation(new SRLatch());

    [Fact]
    public void TFlipFlop_Validate() => TestSimulatation(new TFlipFlop());
}