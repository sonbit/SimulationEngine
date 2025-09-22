using SimulationEngine.Designs.Calculators;
using Xunit.Abstractions;

namespace SimulationEngine.Tests.Designs;

public class CalculatorTests(ITestOutputHelper testOutputHelper) : BaseDesignTest(testOutputHelper)
{
    [Fact]
    public void TT3_BTCalculator_Validate() => TestSimulatation(new TT3_BTCalculator());
}