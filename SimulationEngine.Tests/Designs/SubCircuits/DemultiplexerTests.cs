using SimulationEngine.Designs.SubCircuits.Demultiplexers;
using Xunit.Abstractions;

namespace SimulationEngine.Tests.Designs.SubCircuits;

public class DemultiplexerTests(ITestOutputHelper output) : BaseDesignTest(output)
{
    [Fact]
    public void _3DEMUX_Validate()
    {
        RunTest(new _3DEMUX(), """
            00 000
            02 200
            10 000
            12 020
            10 000
            22 002
            20 000
            02 200
            12 020
            22 002
            10 000
            20 000
            00 000
            """);
    }

    [Fact]
    public void _9DEMUX_Validate()
    {
        RunTest(new _9DEMUX(), """
            000 000000000
            002 200000000
            000 000000000
            012 020000000
            010 000000000
            022 002000000
            020 000000000
            102 000200000
            100 000000000
            112 000020000
            110 000000000
            122 000002000
            120 000000000
            202 000000200
            200 000000000
            212 000000020
            210 000000000
            222 000000002
            220 000000000
            000 000000000
            """);
    }
}
