using static SimulationEngine.REBEL2.Assembly.InstructionSet;

namespace SimulationEngine.REBEL2.Assembly;

internal static class InstructionDisassembler
{
    public static string Disassemble(string instruction)
    {
        if (instruction.Length != 10)
            throw new InvalidOperationException($"Instruction must be 10 trits long, got {instruction.Length}.");

        var opcode = instruction[..2];
        var opcodeEntry = Patterns.FirstOrDefault(kvp => kvp.Value.Opcode == opcode);
        if (string.IsNullOrEmpty(opcodeEntry.Key))
            throw new InvalidOperationException($"Unknown opcode '{opcode}'.");
        var pattern = opcodeEntry.Value;

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
