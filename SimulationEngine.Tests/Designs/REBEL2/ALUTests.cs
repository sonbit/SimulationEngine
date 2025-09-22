using SimulationEngine.Designs.REBEL2.ALU;
using Xunit.Abstractions;

namespace SimulationEngine.Tests.Designs.REBEL2;

public class ALUTests(ITestOutputHelper testOutputHelper) : BaseDesignTest(testOutputHelper)
{
    [Fact]
    public void _2TritComp_Validate() => TestSimulatation(new _2TritComp());

    [Fact]
    public void _2TritMul_Validate() => TestSimulatation(new _2TritMul());

    [Fact]
    public void AddSub2_Validate() => TestSimulatation(new AddSub2());

    [Fact]
    public void ALU2_Validate() => TestSimulatation(new ALU2());

    [Fact]
    public void CMP2_Validate() => TestSimulatation(new CMP2());

    [Fact]
    public void CMP2Tritwise_Validate() => TestSimulatation(new CMP2Tritwise());
}