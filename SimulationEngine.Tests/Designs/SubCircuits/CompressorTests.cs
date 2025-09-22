using SimulationEngine.Designs.SubCircuits.Compressors;
using Xunit.Abstractions;

namespace SimulationEngine.Tests.Designs.SubCircuits;

public class CompressorTests(ITestOutputHelper testOutputHelper) : BaseDesignTest(testOutputHelper)
{
    [Fact]
    public void _4Compressor2_Validate() => TestSimulatation(new _4Compressor2());
}