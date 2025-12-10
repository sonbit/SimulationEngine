using static SimulationEngine.REBEL2.Assembly.InstructionSet;

namespace SimulationEngine.REBEL2.Assembly;

internal static class VectorEmitter
{
    public static IReadOnlyList<string> BuildInputSequence(IEnumerable<string> pageAssemblies, bool padPages, bool annotate = false)
    {
        var sequence = new List<string>();

        foreach (var pageAssembly in pageAssemblies)
        {
            var page = PageAssembler.AssemblePage(pageAssembly, padPages, DefaultPaddingInstruction);
            if (!padPages && page.Count != PageInstructionCount)
                throw new InvalidOperationException($"Page must contain exactly {PageInstructionCount} instructions when padding is disabled.");

            foreach (var instruction in page)
            {
                sequence.Add(FormatInputVector('0', '1', instruction.MachineCode, annotate ? instruction.Assembly : null));
                sequence.Add(FormatInputVector('1', '1', ZeroInstruction));
            }

            for (int i = 0; i < PageInstructionCount; i++)
            {
                sequence.Add(FormatInputVector('0', '0', ZeroInstruction));
                sequence.Add(FormatInputVector('1', '0', ZeroInstruction));
            }
        }

        return sequence;
    }

    private static string FormatInputVector(char clk, char wrInst, string tenTritWord, string? comment = null)
    {
        if (tenTritWord.Length != 10)
            throw new InvalidOperationException($"Instruction must be 10 trits long, got {tenTritWord.Length}.");

        var vector = string.Concat(clk, wrInst, tenTritWord);
        return string.IsNullOrWhiteSpace(comment) ? vector : $"{vector} # {comment}";
    }
}