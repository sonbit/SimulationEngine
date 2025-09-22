using SimulationEngine.Designs.Converters;
using Xunit.Abstractions;

namespace SimulationEngine.Tests.Designs;

public class ConverterTests(ITestOutputHelper testOutputHelper) : BaseDesignTest(testOutputHelper)
{
    [Fact]
    public void BTSignedRadixConverter4_Validate() => TestSimulatation(new BTSignedRadixConverter4());

    [Fact]
    public void SignedBTRadixConverter4_Validate() => TestSimulatation(new SignedBTRadixConverter4());

    [Fact]
    public void TT_UM_TernaryPC_RadixConverter_Validate() => TestSimulatation(new TT_UM_TernaryPC_RadixConverter());

    [Fact]
    public void UnsignedBT_RadixConverter4_Validate() => TestSimulatation(new UnsignedBT_RadixConverter4());
}