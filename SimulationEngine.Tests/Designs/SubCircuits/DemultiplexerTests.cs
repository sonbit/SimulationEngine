using SimulationEngine.Designs.Subcircuits.Demultiplexers;
using Xunit.Abstractions;

namespace SimulationEngine.Tests.Designs.Subcircuits;

public class DemultiplexerTests(ITestOutputHelper testOutputHelper) : BaseDesignTest(testOutputHelper)
{
    [Fact]
    public void _3BDEMUX_Validate() => TestSimulatation(new _3BDEMUX());

    [Fact]
    public void _3DEMUX_Validate() => TestSimulatation(new _3DEMUX());
           
    [Fact]
    public void _9DEMUX_Validate() => TestSimulatation(new _9BDEMUX());

    [Fact]
    public void _DEMUX_Validate() => TestSimulatation(new DEMUX());
}