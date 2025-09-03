using SimulationEngine.Designs.REBEL2.ALU;
using SimulationEngine.Designs.SubCircuits.Adders;
using Xunit.Abstractions;

namespace SimulationEngine.Tests.Designs.SubCircuits;

public class AdderTests(ITestOutputHelper output) : BaseDesignTest(output)
{
    [Fact]
    public void _2TritAdder_Validate()
    {
        RunTest(new _2TritAdder(), """
            0000 012
            0100 020
            0200 021
            1000 022
            1100 100
            1200 101
            2000 102
            2100 110
            2200 111
            2201 112
            2202 120
            2210 121
            2211 122
            2212 200
            2220 201
            2221 202
            2222 210
            2122 202
            2022 201
            1222 200
            1122 122
            1022 121
            0222 120
            0122 112
            0022 111
            0021 110
            0020 102
            0012 101
            0011 100
            0010 022
            0002 021
            0001 020
            0000 012
            """);
    }

    [Fact]
    public void TriFullAdder_Validate()
    {
        RunTest(new TriFullAdder(), """
            000 01
            001 02
            002 10
            010 02
            011 10
            012 11
            020 10
            021 11
            022 12
            100 02
            101 10
            102 11
            110 10
            111 11
            112 12
            120 11
            121 12
            122 20
            200 10
            201 11
            202 12
            210 11
            211 12
            212 20
            220 12
            221 20
            222 21
        """);
    }

    [Fact]
    public void TriHalfAdder_Validate()
    {
        RunTest(new TriHalfAdder(), """
            00 02
            01 10
            02 11
            10 10
            11 11
            12 12
            20 11
            21 12
            22 20
        """);
    }
}
