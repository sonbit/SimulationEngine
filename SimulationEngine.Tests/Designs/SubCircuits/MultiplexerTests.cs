using SimulationEngine.Designs.SubCircuits.Multiplexers;
using Xunit.Abstractions;

namespace SimulationEngine.Tests.Designs.SubCircuits;

public class MultiplexerTests(ITestOutputHelper testOutputHelper) : BaseDesignTest(testOutputHelper)
{
    [Fact]
    public void _2MUX2_Validate() => TestSimulatation(new _2MUX2());

    [Fact]
    public void _3MUX_Validate() => TestSimulatation(new _3MUX());

    [Fact]
    public void _3MUX1_Validate() => TestSimulatation(new _3MUX1());

    [Fact]
    public void _3MUX2_Validate() => TestSimulatation(new _3MUX2());

    [Fact]
    public void _9MUX2_Validate() => TestSimulatation(new _9MUX2());

    [Fact]
    public void MUX_Validate() => TestSimulatation(new MUX());
}