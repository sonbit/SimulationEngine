using SimulationEngine.Designs.REBEL2.Fetch;
using Xunit.Abstractions;

namespace SimulationEngine.Tests.Designs.REBEL2;

public class FetchTests(ITestOutputHelper testOutputHelper) : BaseDesignTest(testOutputHelper)
{
    [Fact]
    public void _2xFetch_Validate() => TestSimulatation(new _2xFetch());

    [Fact]
    public void Fetch_Validate() => TestSimulatation(new Fetch());

    [Fact]
    public void ProgCtr2_Validate() => TestSimulatation(new ProgCtr2());
}