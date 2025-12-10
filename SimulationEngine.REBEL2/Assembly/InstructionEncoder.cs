using SimulationEngine.REBEL2.Assembly.Models;
using static SimulationEngine.REBEL2.Assembly.InstructionSet;

namespace SimulationEngine.REBEL2.Assembly;

internal static class InstructionEncoder
{
    public static string Translate(string instruction)
    {
        var parsed = InstructionParser.ParsePage(instruction);
        if (parsed.Count != 1)
            throw new InvalidOperationException("Translate expects exactly one instruction.");

        return Translate(parsed[0]);
    }

    public static string Translate(ParsedInstruction instruction)
    {
        var mnemonic = instruction.Parts[0];
        var pattern = ResolvePattern(mnemonic) ?? throw new InvalidOperationException($"Unknown mnemonic '{mnemonic}' on line {instruction.LineNumber}.");

        var operands = instruction.Parts.Skip(1).ToList();
        if (operands.Count != pattern.AssemblyOperands.Count)
            throw new InvalidOperationException(
                $"Mnemonic '{mnemonic}' expects {pattern.AssemblyOperands.Count} operand(s) but received {operands.Count} on line {instruction.LineNumber}.");

        // Initialize fields with defaults (00)
        var fields = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            { Rs1, DefaultField },
            { Rs2, DefaultField },
            { Rd1, DefaultField },
            { Rd2, DefaultField },
        };

        if (pattern.Defaults != null)
        {
            foreach (var (key, value) in pattern.Defaults)
                fields[key] = value;
        }

        // Place assembly operands in declared order
        for (int i = 0; i < operands.Count; i++)
        {
            var fieldName = pattern.AssemblyOperands[i];
            var targetField = string.Equals(fieldName, Imm, StringComparison.OrdinalIgnoreCase) ? Rs2 : fieldName;
            var value = ParseOperand(operands[i], targetField, instruction.LineNumber);
            fields[targetField] = value;
        }

        return string.Concat(
            pattern.Opcode,
            fields[Rs1],
            fields[Rs2],
            fields[Rd1],
            fields[Rd2]);
    }

    private static string ParseOperand(string operand, string field, int lineNumber)
    {
        var token = operand.Trim();

        if (RegisterDictionary.TryGetValue(token, out var registerValue))
            return registerValue;

        if (TryParseTritPair(token, out var explicitTrits))
            return explicitTrits;

        if (int.TryParse(token, out var numericValue))
            return ToBalancedTritPair(numericValue, lineNumber);

        throw new InvalidOperationException(
            $"Unable to parse operand '{operand}' for field '{field}' on line {lineNumber}. Labels are not supported in this assembler iteration.");
    }

    private static InstructionPattern? ResolvePattern(string mnemonic)
    {
        if (Patterns.TryGetValue(mnemonic, out var pattern))
            return pattern;

        // If the mnemonic is missing the .t suffix, try with it.
        if (!mnemonic.EndsWith(".T", StringComparison.OrdinalIgnoreCase))
        {
            var withT = $"{mnemonic}.T";
            if (Patterns.TryGetValue(withT, out var patternWithT))
                return patternWithT;
        }

        return null;
    }

    private static bool TryParseTritPair(string token, out string result)
    {
        if (token.Length == 2 && token.All(ch => ch is '+' or '-' or '0'))
        {
            result = token;
            return true;
        }

        result = string.Empty;
        return false;
    }

    private static string ToBalancedTritPair(int value, int lineNumber)
    {
        if (value is < -4 or > 4)
            throw new InvalidOperationException($"Immediate value {value} is outside the 2-trit range (-4..4) on line {lineNumber}.");

        return AddressSpace[value + 4];
    }
}
