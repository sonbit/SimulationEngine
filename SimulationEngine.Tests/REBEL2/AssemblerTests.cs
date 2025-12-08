using SimulationEngine.REBEL2;

namespace SimulationEngine.Tests.REBEL2;

public class AssemblerTests
{
    [Fact]
    public void Translate_Addi_MatchesExample()
    {
        var result = Assembler.Translate("ADDi x0, x-4, ++");
        Assert.Equal("-0--++00--", result);
    }

    [Fact]
    public void Assemble_ResolvesLabelsAndImmediates()
    {
        const string assembly = """
        start: ADDi x0, x-4, ++
        loop: ADD x-4, x0, x1
        PCO x1, loop, 0+
        """;

        var result = Assembler.Assemble(assembly);

        Assert.Collection(result,
            inst => Assert.Equal("-0--++00--", inst),
            inst => Assert.Equal("--000+----", inst),
            inst => Assert.Equal("++-00+0+--", inst));
    }

    [Fact]
    public void Assemble_AllowsLabelOnOwnLine()
    {
        const string assembly = """
        start:
        ADDi x0, x-4, ++
        loop:
        ADD x-4, x0, x1
        PCO x1, loop, 0+
        """;

        var result = Assembler.Assemble(assembly);

        Assert.Collection(result,
            inst => Assert.Equal("-0--++00--", inst),
            inst => Assert.Equal("--000+----", inst),
            inst => Assert.Equal("++-00+0+--", inst));
    }

    [Fact]
    public void Translate_AllowsDecimalImmediate()
    {
        var result = Assembler.Translate("ADDi x1, x-0, -3");
        Assert.Equal("-000-00+--", result);
    }
}
