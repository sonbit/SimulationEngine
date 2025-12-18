using SimulationEngine.Designs.Subcircuits.Memory;
using Xunit.Abstractions;

namespace SimulationEngine.Tests.Designs.Subcircuits;

public class MemoryTests(ITestOutputHelper testOutputHelper) : BaseDesignTest(testOutputHelper)
{
    [Fact]
    public void _8Reg2_Validate() => TestSimulatation(new _8Reg2());

    [Fact]
    public void _8RegArray2_Validate() => TestSimulatation(new _8RegArray2());

    [Fact]
    public void _9Ram2_Validate() => TestSimulatation(new _9Ram2());

    [Fact]
    public void _9Reg2_Validate() => TestSimulatation(new _9Reg2());

    [Fact]
    public void _9Reg2_1_Validate() => TestSimulatation(new _9Reg2_1());

    [Fact]
    public void _9Reg10_1_Validate() => TestSimulatation(new _9Reg10_1());

    [Fact]
    public void RAM3_Validate() => TestSimulatation(new RAM3());

    [Fact]
    public void Register9_Validate() => TestSimulatation(new Register9());
}