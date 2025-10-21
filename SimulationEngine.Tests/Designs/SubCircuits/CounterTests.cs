using SimulationEngine.Designs.Subcircuits.Counters;
using Xunit.Abstractions;

namespace SimulationEngine.Tests.Designs.Subcircuits;

public class CounterTests(ITestOutputHelper testOutputHelper) : BaseDesignTest(testOutputHelper)
{
    [Fact]
    public void SyTriDirLoadCounter_Validate() => TestSimulatation(new SyTriDirLoadCounter());

    [Fact]
    public void SyTriDirLoadCounter4_Validate() => TestSimulatation(new SyTriDirLoadCounter4());
}