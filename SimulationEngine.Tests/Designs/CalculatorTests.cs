using SimulationEngine.Designs.Calculators;
using Xunit.Abstractions;

namespace SimulationEngine.Tests.Designs;

public class CalculatorTests(ITestOutputHelper output) : BaseDesignTest(output)
{
    [Fact]
    public void TT3_BTCalculator_Validate()
    {
        RunTest(new TT3_BTCalculator(), """
            0000 2002
            0001 1221
            0010 1122
            0011 1111
            0020 1012
            0021 1001
            0100 1221
            0101 1211
            0110 1121
            0111 1111
            0120 1021
            0121 1011
            0200 1210
            0201 1201
            0210 1120
            0211 1111
            0220 1100
            0221 1021
            1000 1111
            1001 1111
            1010 1111
            1011 1111
            1020 1111
            1021 1111
            1100 1111
            1101 1111
            1110 1111
            1111 1111
            1120 1111
            1121 1111
            1200 1111
            1201 1111
            1210 1111
            1211 1111
            1220 1111
            1221 1111
            """);
    }
}
