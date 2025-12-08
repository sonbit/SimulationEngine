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
    public void AssembleInstructions_ResolvesLabelsAndImmediates()
    {
        const string assembly = """
        start: ADDi x0, x-4, ++
        loop: ADD x-4, x0, x1
        PCO x1, loop, 0+
        """;

        var result = Assembler.AssembleInstructions(assembly);

        Assert.Collection(result,
            inst => Assert.Equal("-0--++00--", inst),
            inst => Assert.Equal("--000+----", inst),
            inst => Assert.Equal("++-00+0+--", inst));
    }

    [Fact]
    public void AssembleInstructions_AllowsLabelOnOwnLine()
    {
        const string assembly = """
        start:
        ADDi x0, x-4, ++
        loop:
        ADD x-4, x0, x1
        PCO x1, loop, 0+
        """;

        var result = Assembler.AssembleInstructions(assembly);

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
    public void AssemblePageInstructions_PadsWithDefaultInstruction()
    {
        const string assembly = "ADDi x0, x-4, ++";
        var result = Assembler.AssemblePageInstructions(assembly);

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
        Assert.Equal("110000000000", sequence[1]);

        // After programming, execution phase uses WrInst=0 and zeroed data.
        var executeStart = 18; // 9 instructions * 2 edges
        Assert.Equal("000000000000", sequence[executeStart]);
        Assert.Equal("100000000000", sequence[executeStart + 1]);
    }

    [Fact]
    public void Assemble_DefaultsToInputSequence()
    {
        const string assembly = "ADDi x0, x-4, ++";
        var sequence = Assembler.Assemble(assembly);

        Assert.Equal(36, sequence.Count);
        Assert.Equal("01-0--++00--", sequence[0]);
        Assert.Equal("110000000000", sequence[1]);
    }

    [Fact]
    public void DefaultProgram_RoundTripsThroughAssembler()
    {
        var pages = new[]
        {
            // ROM PAGE 1: RESET RAM & LOAD CONSTANTS
            """
            ADDi x0, x-4, ++
            ADDi x1, x0, 0-
            ADDi x2, x0, -0
            ADDi x0, x-4, ++
            ADDi x0, x-4, ++
            ADDi x0, x-4, ++
            ADDi x0, x-4, ++
            ADDi x0, x-4, ++
            ADDi x0, x-4, ++
            """,
            // ROM PAGE 2: TEST REBEL-2 INSTRUCTIONS -- to 00
            """
            ADD x-4, x0, x1
            ADD x-3, x0, x1
            ADDi x-2, x0, ++
            ADDi x0, x0, 00
            MUDI x-1, x2, x1
            MIMA x3, x2, x1
            MIMA x4, x1, x1
            MIMA x3, x2, x1
            MIMA x4, x2, x2
            """,
            // ROM PAGE 3: TEST REBEL-2 INSTRUCTIONS 0+ to ++
            """
            SHI x-4, x-4, 0+
            SHI x-3, x-3, 0+
            SHI x-2, x-2, +-
            COMP x-1, x1, x2
            COMP x-1, x1, x0
            MIMA x0, x0, x0
            MIMA x0, x0, x0
            MIMA x0, x0, x0
            PCO x4, x0, x0
            """
        };

        var inputs = Assembler.AssemblePages(pages);

        var disassembledPages = ExtractInstructionPages(inputs)
            .Select(page => string.Join(Environment.NewLine, page.Select(Assembler.Disassemble)))
            .ToArray();

        var regeneratedInputs = Assembler.AssemblePages(disassembledPages, padPages: false);

        Assert.Equal(inputs.Count, regeneratedInputs.Count);
        Assert.Equal(inputs, regeneratedInputs);
    }

    private static IEnumerable<List<string>> ExtractInstructionPages(IReadOnlyList<string> inputs)
    {
        var page = new List<string>();
        foreach (var input in inputs)
        {
            if (input.Length < 12)
                continue;

            var clk = input[0];
            var wrInst = input[1];

            if (clk == '0' && wrInst == '1')
            {
                page.Add(input[2..]);
                if (page.Count == 9)
                {
                    yield return page;
                    page = new List<string>();
                }
            }
        }

        if (page.Count > 0)
            throw new InvalidOperationException($"Incomplete page with {page.Count} instructions found.");
    }
}
