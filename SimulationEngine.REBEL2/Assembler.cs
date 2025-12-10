using SimulationEngine.REBEL2.Assembly;
using SimulationEngine.REBEL2.Assembly.Models;
using static SimulationEngine.REBEL2.Assembly.InstructionSet;

namespace SimulationEngine.REBEL2;

/// <summary>
/// Facade for assembling REBEL-2 programs into machine code and simulator input vectors.
/// </summary>
public static class Assembler
{
    /// <summary>
    /// Assemble a single page and emit the full input vector sequence (program + execute).
    /// </summary>
    public static IReadOnlyList<string> Assemble(string assembly, bool padPage = true, bool annotate = false) =>
        BuildInputSequence([assembly], padPage, annotate);

    /// <summary>
    /// Assemble multiple pages and emit the full input vector sequence (program + execute).
    /// </summary>
    public static IReadOnlyList<string> AssemblePages(IEnumerable<string> pageAssemblies, bool padPages = true, bool annotate = false) =>
        BuildInputSequence(pageAssemblies, padPages, annotate);

    /// <summary>
    /// Assemble a block of REBEL2 assembly into a list of 10-trit machine code strings.
    /// Labels are intentionally not supported in this iteration.
    /// </summary>
    public static IReadOnlyList<string> AssembleInstructions(string assembly) =>
        [.. PageAssembler.AssemblePage(assembly, padPage: false, DefaultPaddingInstruction).Select(inst => inst.MachineCode)];

    /// <summary>
    /// Assemble a page and pad with NOP-like instructions to fill all 9 slots.
    /// </summary>
    public static IReadOnlyList<string> AssemblePageInstructions(string assembly, string? padInstruction = null) =>
        [.. AssemblePage(assembly, padPage: true, padInstruction).Select(inst => inst.MachineCode)];

    /// <summary>
    /// Assemble a page and return instruction metadata (address, assembly, machine code).
    /// </summary>
    public static IReadOnlyList<AssembledInstruction> AssemblePage(string assembly, bool padPage = true, string? padInstruction = null) =>
        PageAssembler.AssemblePage(assembly, padPage, padInstruction ?? DefaultPaddingInstruction);

    /// <summary>
    /// Build the full input vector sequence for one or more ROM pages:
    ///  - For each page, load instructions with WrInst=1, clock toggling each row (data on falling edge, zeros on rising).
    ///  - Then execute the page once by clocking through all 9 addresses with WrInst=0.
    /// </summary>
    /// <param name="pageAssemblies">Assembly strings, one per page.</param>
    /// <param name="padPages">If true, short pages are padded to 9 slots with a NOP-like instruction.</param>
    /// <param name="annotate">Append human-readable comments that show which assembly instruction is being programmed or executed.</param>
    /// <returns>Lines of 12 symbols (Clk, WrInst, 10-trit word) ready for TestStringConverter.</returns>
    public static IReadOnlyList<string> BuildInputSequence(IEnumerable<string> pageAssemblies, bool padPages = true, bool annotate = false) =>
        VectorEmitter.BuildInputSequence(pageAssemblies, padPages, annotate);

    /// <summary>
    /// Translate a single instruction without label resolution.
    /// </summary>
    public static string Translate(string instruction) =>
        InstructionEncoder.Translate(instruction);

    /// <summary>
    /// Disassemble a 10-trit machine instruction back into mnemonic and operands.
    /// Useful for round-tripping existing ROM listings.
    /// </summary>
    public static string Disassemble(string instruction) =>
        InstructionDisassembler.Disassemble(instruction);
}