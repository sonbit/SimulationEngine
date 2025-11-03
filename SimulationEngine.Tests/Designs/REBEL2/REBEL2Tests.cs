using Xunit.Abstractions;

namespace SimulationEngine.Tests.Designs.REBEL2;

public class REBEL2Tests(ITestOutputHelper testOutputHelper) : BaseDesignTest(testOutputHelper)
{
    [Fact]
    public void REBEL2_Validate() 
    {
        var rebel2 = new SimulationEngine.Designs.REBEL2.REBEL2();

        TestSimulatation(rebel2, [
            //rebel2.Subcircuits[0], // PC
            //rebel2.Subcircuits[1], // ROM Output
            rebel2.Subcircuits[1].Subcircuits[0].Subcircuits[1], // ROM FlipFlops
            //rebel2.Subcircuits[3], // RAM Output
            //rebel2.Subcircuits[3].Subcircuits[1] // RAM FlipFlops
            ], """
            00-00000--00 $ CommentStyle1
            01-00000--00 # CommentStyle2
            00-00000-000
            01-00000-000
            00-00000-+00
            01-00000-+00
            00-000000-00
            01-000000-00
            00-000000000
            01-000000000
            00-000000+00
            01-000000+00
            00-00000+-00
            01-00000+-00
            00-00000+000
            01-00000+000
            00-00000++00
            01-00000++00
        """, true);
    } 
}