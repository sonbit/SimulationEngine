using SimulationEngine.Designs.REBEL2.Control;
using Xunit.Abstractions;

namespace SimulationEngine.Tests.Designs.REBEL2;

public class CPUControlTests(ITestOutputHelper testOutputHelper) : BaseDesignTest(testOutputHelper)
{
    [Fact]
    public void AluControlFlow_Validate() => TestSimulatation(new AluControlFlow(), true);

    [Fact]
    public void AluControlWithShift_Validate() => TestSimulatation(new AluControlWithShift(), true);

    [Fact]
    public void CPUControl_Validate() => TestSimulatation(new CPUControl(), true);

    [Fact]
    public void MuxControl_Validate() => TestSimulatation(new MuxControl());
}
