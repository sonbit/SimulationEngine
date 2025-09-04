using SimulationEngine.Designs.SubCircuits.Compressors;
using Xunit.Abstractions;

namespace SimulationEngine.Tests.Designs.SubCircuits;

public class CompressorTests(ITestOutputHelper output) : BaseDesignTest(output)
{
    [Fact]
    public void _4Compressor2_Test()
    {
        RunTest(new _4Compressor2(), """
            0000 00
            0001 01
            0002 02
            0010 01
            0011 02
            0012 10
            0020 02
            0021 10
            0022 11
            0100 01
            0101 02
            0102 10
            0110 02
            0111 10
            0112 11
            0120 10
            0121 11
            0122 12
            0200 02
            0201 10
            0202 11
            0210 10
            0211 11
            0212 12
            0220 11
            0221 12
            0222 20
            1000 01
            1001 02
            1002 10
            1010 02
            1011 10
            1012 11
            1020 10
            1021 11
            1022 12
            1100 02
            1101 10
            1102 11
            1110 10
            1111 11
            1112 12
            1120 11
            1121 12
            1122 20
            1200 10
            1201 11
            1202 12
            1210 11
            1211 12
            1212 20
            1220 12
            1221 20
            1222 21
            2000 02
            2001 10
            2002 11
            2010 10
            2011 11
            2012 12
            2020 11
            2021 12
            2022 20
            2100 10
            2101 11
            2102 12
            2110 11
            2111 12
            2112 20
            2120 12
            2121 20
            2122 21
            2200 11
            2201 12
            2202 20
            2210 12
            2211 20
            2212 21
            2220 20
            2221 21
            2222 22
            """);
    }
}
