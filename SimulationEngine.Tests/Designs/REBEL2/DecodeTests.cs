using SimulationEngine.Designs.REBEL2.Decode;
using Xunit.Abstractions;

namespace SimulationEngine.Tests.Designs.REBEL2;

public class DecodeTests(ITestOutputHelper testOutputHelper) : BaseDesignTest(testOutputHelper)
{
    [Fact]
    public void _2xDecode_Validate() => TestSimulatation(new _2xDecode());

    [Fact]
    public void ALUCtrl2_Validate() => TestSimulatation(new ALUCtrl2());

    [Fact]
    public void Decode_Validate() => TestSimulatation(new Decode());

    [Fact]
    public void ExecCtrl_Validate() => TestSimulatation(new ExecCtrl());
}