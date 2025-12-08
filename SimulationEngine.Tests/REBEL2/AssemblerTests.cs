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

    [Fact]
    public void AssemblePage_PadsWithDefaultInstruction()
    {
        const string assembly = "ADDi x0, x-4, ++";
        var result = Assembler.AssemblePage(assembly);

        Assert.Equal(9, result.Count);
        Assert.Equal("-0--++00--", result[0]);
        Assert.True(result.Skip(1).All(instr => instr == Assembler.Translate("ADDi x0, x-0, 00")));
    }

    [Fact]
    public void BuildInputSequence_ProgramsAndExecutesPage()
    {
        const string assembly = "ADDi x0, x-4, ++";

        var sequence = Assembler.BuildInputSequence([assembly]);

        // For one page: 9 instructions * 2 clock edges to program + 9*2 to execute = 36 lines.
        Assert.Equal(36, sequence.Count);

        // First line should be program edge low->high with instruction data.
        Assert.Equal("01-0--++00--", sequence[0]);
        Assert.Equal("11-0--++00--", sequence[1]);

        // After programming, execution phase uses WrInst=0 and zeroed data.
        var executeStart = 18; // 9 instructions * 2 edges
        Assert.Equal("000000000000", sequence[executeStart]);
        Assert.Equal("100000000000", sequence[executeStart + 1]);
    }
}
