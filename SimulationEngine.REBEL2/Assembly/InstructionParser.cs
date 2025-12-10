using SimulationEngine.REBEL2.Assembly.Models;
using static SimulationEngine.REBEL2.Assembly.InstructionSet;

namespace SimulationEngine.REBEL2.Assembly;

internal static class InstructionParser
{
    public static List<ParsedInstruction> ParsePage(string assembly)
    {
        var instructions = new List<ParsedInstruction>(PageInstructionCount);
        var lines = assembly.Split(NewLineSeparators, StringSplitOptions.None);

        for (int i = 0; i < lines.Length; i++)
        {
            var lineNumber = i + 1;
            var line = StripComments(lines[i]).Trim();
            if (string.IsNullOrWhiteSpace(line))
                continue;

            if (line.Contains(':'))
                throw new InvalidOperationException($"Labels are not supported in this assembler iteration (line {lineNumber}).");

            var parts = line.Split(ArgumentSeparators, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length == 0)
                throw new InvalidOperationException($"Missing mnemonic on line {lineNumber}.");

            instructions.Add(new ParsedInstruction(lineNumber, line, parts));
            if (instructions.Count > PageInstructionCount)
                throw new InvalidOperationException("Cannot encode more than 9 instructions in a single ROM page.");
        }

        return instructions;
    }

    public static string StripComments(string line)
    {
        line = line.Replace("\"", string.Empty);

        while (true)
        {
            var start = line.IndexOf('(');
            if (start < 0)
                break;
            var end = line.IndexOf(')', start + 1);
            if (end < 0)
                line = line[..start];
            else
                line = line.Remove(start, end - start + 1);
        }

        var hashIndex = line.IndexOf('#');
        var semicolonIndex = line.IndexOf(';');
        var dollarIndex = line.IndexOf('$');
        var slashIndex = line.IndexOf("//", StringComparison.Ordinal);

        var first = new[] { hashIndex, semicolonIndex, dollarIndex, slashIndex }.Where(idx => idx >= 0).DefaultIfEmpty(-1).Min();
        return first >= 0 ? line[..first] : line;
    }
}
