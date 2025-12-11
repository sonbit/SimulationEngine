using SimulationEngine.REBEL2.Assembly.Models;
using static SimulationEngine.REBEL2.Assembly.InstructionSet;

namespace SimulationEngine.REBEL2.Assembly;

internal static class InstructionDisassembler
{
    public static string Disassemble(string instruction)
    {
        if (instruction.Length != 10)
            throw new InvalidOperationException($"Instruction must be 10 trits long, got {instruction.Length}.");

        var opcode = instruction[..2];
        var rs1 = instruction[2..4];
        var rs2 = instruction[4..6];
        var rd1 = instruction[6..8];
        var rd2 = instruction[8..10];

        var fields = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            { Rs1, rs1 },
            { Rs2, rs2 },
            { Rd1, rd1 },
            { Rd2, rd2 },
        };

        var pattern = ResolvePattern(opcode, fields) ?? throw new InvalidOperationException($"Unknown opcode '{opcode}'.");
        var operands = new List<string>();
        foreach (var fieldName in pattern.AssemblyOperands)
        {
            var sourceField = string.Equals(fieldName, Imm, StringComparison.OrdinalIgnoreCase) ? Rs2 : fieldName;
            operands.Add(FormatOperand(fields[sourceField]));
        }

        return operands.Count == 0
            ? pattern.Mnemonic
            : $"{pattern.Mnemonic} {string.Join(", ", operands)}";
    }

    private static InstructionPattern? ResolvePattern(string opcode, IReadOnlyDictionary<string, string> fields)
    {
        var matches = Patterns.Values
            .Select((pattern, index) => new { pattern, index, matchCount = ScorePattern(pattern, opcode, fields) })
            .Where(x => x.matchCount >= 0)
            .OrderByDescending(x => x.matchCount)
            .ThenBy(x => x.index)
            .FirstOrDefault();

        return matches?.pattern;
    }

    private static int ScorePattern(InstructionPattern pattern, string opcode, IReadOnlyDictionary<string, string> fields)
    {
        if (!string.Equals(pattern.Opcode, opcode, StringComparison.Ordinal))
            return -1;

        var assemblyFields = pattern.AssemblyOperands
            .Select(op => string.Equals(op, Imm, StringComparison.OrdinalIgnoreCase) ? Rs2 : op)
            .ToHashSet(StringComparer.OrdinalIgnoreCase);

        var score = 0;
        foreach (var fieldName in FieldOffsets.Keys.Where(f => !string.Equals(f, "opcode", StringComparison.OrdinalIgnoreCase)))
        {
            if (assemblyFields.Contains(fieldName))
                continue;

            var expected = DefaultField;
            if (pattern.Defaults != null && pattern.Defaults.TryGetValue(fieldName, out var defaultValue))
                expected = defaultValue;

            if (!string.Equals(fields[fieldName], expected, StringComparison.Ordinal))
                return -1;

            score++;
        }

        return score;
    }

    private static string FormatOperand(string fieldValue)
    {
        foreach (var kvp in RegisterDictionary)
        {
            if (kvp.Value == fieldValue)
                return kvp.Key;
        }

        var numericIndex = Array.IndexOf(AddressSpace, fieldValue);
        if (numericIndex >= 0)
            return (numericIndex - 4).ToString();

        return fieldValue;
    }
}
