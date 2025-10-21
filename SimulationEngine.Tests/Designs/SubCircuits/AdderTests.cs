using SimulationEngine.Designs.Subcircuits.Adders;
using Xunit.Abstractions;

namespace SimulationEngine.Tests.Designs.Subcircuits;

public class AdderTests(ITestOutputHelper testOutputHelper) : BaseDesignTest(testOutputHelper)
{
    [Fact]
    public void _2TritAdder_Validate() => TestSimulatation(new _2TritAdder());

    [Fact]
    public void TriFullAdder_Validate() => TestSimulatation(new TriFullAdder());

    [Fact]
    public void TriHalfAdder_Validate() => TestSimulatation(new TriHalfAdder());
}