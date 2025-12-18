using SimulationEngine.Designs.REBEL2.Control;
using Xunit.Abstractions;

namespace SimulationEngine.Tests.Designs.REBEL2;

public class CPUControlTests(ITestOutputHelper testOutputHelper) : BaseDesignTest(testOutputHelper)
{
    [Fact]
    public void MuxControl_Validate() => TestSimulatation(new MuxControl());
}
