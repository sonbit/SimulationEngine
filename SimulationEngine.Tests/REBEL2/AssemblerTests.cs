using SimulationEngine.REBEL2;

namespace SimulationEngine.Tests.REBEL2;

public class AssemblerTests
{
    [Fact]
    public void Translate_Add()
    {
        Assert.Equal("--+-+00+00", Assembler.Translate("ADD.T x1, x2, x3"));
        Assert.Equal("--+-+00+--", Assembler.Translate("SUB.T x1, x2, x3"));
        Assert.Equal("--00+00+--", Assembler.Translate("STI.T x1, x3"));
    }

    [Fact]
    public void Translate_Addi()
    {
        Assert.Equal("-0+-++0+00", Assembler.Translate("ADDi.T x1, x2, ++"));
        Assert.Equal("-000000000", Assembler.Translate("NOP.T"));
        Assert.Equal("-000++0+00", Assembler.Translate("LI.T x1, ++"));
        Assert.Equal("-0+-000+00", Assembler.Translate("MV.T x1, x2"));
    }

    [Fact]
    public void Translate_Addi2()
    {
        Assert.Equal("-+++--0++-", Assembler.Translate("ADDi2.T x1, x2, ++, --"));
    }

    [Fact]
    public void Translate_MUDI()
    {
        Assert.Equal("0-+-+00+00", Assembler.Translate("MUL.T x1, x2, x3"));
        Assert.Equal("0-+-+00+00", Assembler.Translate("MULU.T x1, x2, x3"));
        Assert.Equal("0-+-+00+00", Assembler.Translate("DIV.T x1, x2, x3"));
        Assert.Equal("0-+-+00+00", Assembler.Translate("REM.T x1, x2, x3"));
    }

    [Fact]
    public void Translate_MIMA()
    {
        Assert.Equal("00+-+00+--", Assembler.Translate("MINW.T x1, x2, x3"));
        Assert.Equal("00+-+00+-0", Assembler.Translate("MINT.T x1, x2, x3"));
        Assert.Equal("00+-+00++-", Assembler.Translate("MAXW.T x1, x2, x3"));
        Assert.Equal("00+-+00++0", Assembler.Translate("MAXT.T x1, x2, x3"));
    }

    [Fact]
    public void Translate_SHI()
    {
        Assert.Equal("0++-++0+0+", Assembler.Translate("SLI.T x1, x2, ++, 0+"));
        Assert.Equal("0++-++0++0", Assembler.Translate("SRI.T x1, x2, ++, +0"));
        Assert.Equal("0++-++0+0+", Assembler.Translate("SC.T x1, x2, ++, 0+"));
    }

    [Fact]
    public void Translate_CMP()
    {
        Assert.Equal("+-+-+00+00", Assembler.Translate("CMPW.T x1, x2, x3"));
        Assert.Equal("+-+-+00+--", Assembler.Translate("CMPT.T x1, x2, x3"));
    }

    [Fact]
    public void Translate_BCEG()
    {
        Assert.Equal("+0+0++0++-", Assembler.Translate("BCEG.T x1, x2, x3, x4"));
    }

    [Fact]
    public void Translate_PCO()
    {
        Assert.Equal("++00++0+0+", Assembler.Translate("JAL.T x1, ++"));
        Assert.Equal("+++-++0+00", Assembler.Translate("JALR.T x1, x2, ++"));
        Assert.Equal("++00++0+0-", Assembler.Translate("LPC.T x1, ++"));
    }

    [Fact]
    public void Assemble_DefaultsToInputSequence()
    {
        const string assembly = "ADDi x-4, x0, ++";
        var sequence = Assembler.Assemble(assembly);

        Assert.Equal(36, sequence.Count);
        Assert.StartsWith("01-000++--00", sequence[0]);
        Assert.StartsWith("110000000000", sequence[1]);
    }

    [Fact]
    public void AssembleInstructions_ResolvesLabels()
    {
        const string assembly = """
        start:
            ADDi x0, x-4, ++
        loop: ADD x-4, x0, x1
              PCO x1, loop, 0+
        """;

        var result = Assembler.AssembleInstructions(assembly);

        Assert.Equal("-0--++0000", result[0]);
        Assert.Equal("--000+--00", result[1]);
        Assert.Equal("++-00+0+00", result[2]);
    }

    [Fact]
    public void AssembleInstructions_AllowsForwardLabelReference()
    {
        const string assembly = """
              PCO x0, target, 00
        target:
              NOP.T
        """;

        var result = Assembler.AssembleInstructions(assembly);

        Assert.Equal(2, result.Count);
        Assert.Equal(Assembler.Translate("PCO x0, -0, 00"), result[0]);
        Assert.Equal("-000000000", result[1]);
    }

    [Fact]
    public void AssembleInstructions_ThrowsOnUnknownLabel()
    {
        const string assembly = """
        ADDi x0, x-4, ++
        PCO x1, missing, 0+
        """;

        var ex = Assert.Throws<InvalidOperationException>(() => Assembler.AssembleInstructions(assembly));
        Assert.Contains("missing", ex.Message);
    }

    [Fact]
    public void AssembleInstructions_ThrowsWhenLabelIsNotAttachedToInstruction()
    {
        const string assembly = "dangling:";

        var ex = Assert.Throws<InvalidOperationException>(() => Assembler.AssembleInstructions(assembly));
        Assert.Contains("dangling", ex.Message);
    }

    [Fact]
    public void AssemblePageInstructions_PadsWithDefaultInstruction()
    {
        const string assembly = "ADDi x0, x-4, ++";
        var result = Assembler.AssemblePageInstructions(assembly);

        Assert.Equal(9, result.Count);
        Assert.Equal("-0--++0000", result[0]);
        Assert.True(result.Skip(1).All(instr => instr == Assembler.Translate("ADDi x0, x-0, 00")));
    }

    [Fact]
    public void BuildInputSequence_AnnotatesAssemblyWhenRequested()
    {
        const string assembly = "ADDi x1, x0, --";

        var sequence = Assembler.BuildInputSequence([assembly], annotate: true);

        Assert.Contains("ADDi x1, x0, --", sequence[0]);
        Assert.StartsWith("01-000--0+00", sequence[0]);
    }

    [Fact]
    public void BuildInputSequence_ProgramsAndExecutesPage()
    {
        const string assembly = "ADDi x0, x-4, ++";

        var sequence = Assembler.BuildInputSequence([assembly]);

        Assert.Equal(36, sequence.Count);
        Assert.Equal("01-0--++0000", sequence[0]);
        Assert.Equal("110000000000", sequence[1]);

        var executeStart = 18;
        Assert.Equal("000000000000", sequence[executeStart]);
        Assert.Equal("100000000000", sequence[executeStart + 1]);
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
            MUL.T x-1, x2, x1
            MINW.T x3, x2, x1
            MINT.T x4, x1, x1
            MAXW.T x3, x2, x1
            MAXT.T x4, x2, x2
            """,
            // ROM PAGE 3: TEST REBEL-2 INSTRUCTIONS 0+ to ++
            """
            SHI x-4, x-4, 0+, x4
            SHI x-3, x-3, 0+, x3
            SHI x-2, x-2, +-, x2
            CMPW.T x-1, x1, x2
            CMPW.T x-1, x1, x0
            MINW.T x0, x0, x0
            MINT.T x0, x0, x0
            MAXW.T x0, x0, x0
            JALR.T x4, x0, 00
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

    [Fact]
    public void Translate_SkipsQuotesAndComments()
    {
        var withQuotes = Assembler.Translate("LI.T x1, \"0+\" (x0 is hardwired 0)");
        Assert.Equal("-0000+0+00", withQuotes);

        var withHash = Assembler.Translate("ADDi x0, x-4, ++ # write plus plus");
        Assert.Equal("-0--++0000", withHash);

        var withDollar = Assembler.Translate("ADDi x0, x-4, ++ $ dollar comment");
        Assert.Equal("-0--++0000", withDollar);

        var withSemicolon = Assembler.Translate("ADDi x0, x-4, ++ ; semicolon");
        Assert.Equal("-0--++0000", withSemicolon);
    }

    private static IEnumerable<List<string>> ExtractInstructionPages(IReadOnlyList<string> inputs)
    {
        var page = new List<string>();
        foreach (var input in inputs)
        {
            var machinePortion = input.Split('#')[0].TrimEnd();
            if (machinePortion.Length < 12)
                continue;

            var clk = machinePortion[0];
            var wrInst = machinePortion[1];

            if (clk == '0' && wrInst == '1')
            {
                page.Add(machinePortion[2..12]);
                if (page.Count == 9)
                {
                    yield return page;
                    page = [];
                }
            }
        }

        if (page.Count > 0)
            throw new InvalidOperationException($"Incomplete page with {page.Count} instructions found.");
    }
}
