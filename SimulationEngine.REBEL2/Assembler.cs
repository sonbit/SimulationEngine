using System;
using System.Collections.Generic;
using System.Linq;

namespace SimulationEngine.REBEL2;

public static class Assembler
{
    private const string DefaultField = "--";
    private static readonly char[] ArgumentSeparators = [' ', '\t', ','];
    private static readonly string[] AddressSpace = ["--", "-0", "-+", "0-", "00", "0+", "+-", "+0", "++"];
    private static readonly string[] NewLineSeparators = ["\r\n", "\n", "\r"];

    private enum Inst
    {
        RD1,
        RD2,
        RS1,
        RS2,
        IMM
    }

    private sealed record InstructionDefinition(
        string Opcode,
        IReadOnlyList<Inst> OperandOrder,
        IReadOnlyDictionary<Inst, string>? FieldDefaults = null);

    // Adjust these definitions as new instructions are added or operand layouts change.
    private static readonly Dictionary<string, InstructionDefinition> InstructionSet = new(StringComparer.OrdinalIgnoreCase)
    {
        { "ADD",   new InstructionDefinition("--", [Inst.RD1, Inst.RS1, Inst.RS2]) },
        { "ADDi",  new InstructionDefinition("-0", [Inst.RD1, Inst.RS1, Inst.IMM]) },
        { "ADDi2", new InstructionDefinition("-+", [Inst.RD1, Inst.RD2, Inst.IMM]) },

        { "MUDI",  new InstructionDefinition("0-", [Inst.RD1, Inst.RS1, Inst.RS2]) },
        { "MIMA",  new InstructionDefinition("00", [Inst.RD1, Inst.RS1, Inst.RS2]) },
        { "SHI",   new InstructionDefinition("0+", [Inst.RD1, Inst.RS1, Inst.IMM]) },

        { "COMP",  new InstructionDefinition("+-", [Inst.RD1, Inst.RS1, Inst.RS2]) },
        { "BCEG",  new InstructionDefinition("+0", [Inst.RD1, Inst.RS1, Inst.IMM]) },
        { "PCO",   new InstructionDefinition("++", [Inst.RD1, Inst.RS1, Inst.IMM]) },
    };

    private static readonly Dictionary<string, string> RegisterDictionary = new(StringComparer.OrdinalIgnoreCase)
    {
        { "X-4",    "--" },
        { "X-3",    "-0" },
        { "X-2",    "-+" },

        { "X-1",    "0-" },
        { "X-0",    "00" },
        { "X0",     "00" },
        { "X1",     "0+" },

        { "X2",     "+-" },
        { "X3",     "+0" },
        { "X4",     "++" },
    };

    /// <summary>
    /// Assemble a block of REBEL2 assembly into a list of 10-trit machine code strings.
    /// Labels are resolved within a single ROM page (9 instructions).
    /// </summary>
    public static IReadOnlyList<string> Assemble(string assembly)
    {
        var labelDictionary = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        var instructions = new List<(int lineNumber, string text)>();

        var lines = assembly.Split(NewLineSeparators, StringSplitOptions.None);
        for (int i = 0; i < lines.Length; i++)
        {
            var lineNumber = i + 1;
            var line = StripComments(lines[i]).Trim();
            if (string.IsNullOrWhiteSpace(line))
                continue;

            var colonIndex = line.IndexOf(':');
            if (colonIndex >= 0)
            {
                var label = line[..colonIndex].Trim();
                if (string.IsNullOrWhiteSpace(label))
                    throw new InvalidOperationException($"Empty label on line {lineNumber}.");

                if (labelDictionary.ContainsKey(label))
                    throw new InvalidOperationException($"Duplicate label '{label}' on line {lineNumber}.");

                if (instructions.Count >= AddressSpace.Length)
                    throw new InvalidOperationException($"Label '{label}' would point outside the 9-word ROM page (line {lineNumber}).");

                labelDictionary[label] = AddressSpace[instructions.Count];
                line = line[(colonIndex + 1)..].Trim();
                if (line.Length == 0)
                    continue;
            }

            instructions.Add((lineNumber, line));
            if (instructions.Count > AddressSpace.Length)
                throw new InvalidOperationException("Cannot encode more than 9 instructions in a single ROM page.");
        }

        return instructions
            .Select(inst => Translate(inst.text, labelDictionary, inst.lineNumber))
            .ToList();
    }

    /// <summary>
    /// Translate a single instruction without label resolution.
    /// </summary>
    public static string Translate(string instruction)
    {
        var cleaned = StripComments(instruction).Trim();
        return Translate(cleaned, new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase), 0);
    }

    private static string Translate(string instruction, IReadOnlyDictionary<string, string> labels, int lineNumber)
    {
        var parts = instruction
            .Split(ArgumentSeparators, StringSplitOptions.RemoveEmptyEntries);

        if (parts.Length == 0)
            throw new InvalidOperationException($"Missing mnemonic on line {lineNumber}.");

        var mnemonic = parts[0];
        if (!InstructionSet.TryGetValue(mnemonic, out var definition))
            throw new InvalidOperationException($"Unknown mnemonic '{mnemonic}' on line {lineNumber}.");

        var operands = parts.Skip(1).ToList();
        if (operands.Count != definition.OperandOrder.Count)
            throw new InvalidOperationException(
                $"Mnemonic '{mnemonic}' expects {definition.OperandOrder.Count} operand(s) but received {operands.Count} on line {lineNumber}.");

        var fields = new Dictionary<Inst, string>
        {
            { Inst.RS1, DefaultField },
            { Inst.RS2, DefaultField },
            { Inst.RD1, DefaultField },
            { Inst.RD2, DefaultField },
        };

        if (definition.FieldDefaults != null)
        {
            foreach (var (key, value) in definition.FieldDefaults)
                fields[key] = value;
        }

        for (int i = 0; i < operands.Count; i++)
        {
            var operandTarget = definition.OperandOrder[i];
            var value = ParseOperand(operands[i], operandTarget, labels, lineNumber);
            var targetField = operandTarget == Inst.IMM ? Inst.RS2 : operandTarget;

            if (fields[targetField] != DefaultField && fields[targetField] != value)
                throw new InvalidOperationException($"Field '{targetField}' already set when parsing operand {i + 1} on line {lineNumber}.");

            fields[targetField] = value;
        }

        return string.Concat(definition.Opcode, fields[Inst.RS1], fields[Inst.RS2], fields[Inst.RD1], fields[Inst.RD2]);
    }

    private static string ParseOperand(string operand, Inst field, IReadOnlyDictionary<string, string> labels, int lineNumber)
    {
        var token = operand.Trim();

        if (labels.TryGetValue(token, out var labelValue))
            return labelValue;

        if (RegisterDictionary.TryGetValue(token, out var registerValue))
            return registerValue;

        if (TryParseTritPair(token, out var explicitTrits))
            return explicitTrits;

        if (int.TryParse(token, out var numericValue))
            return ToBalancedTritPair(numericValue, lineNumber);

        throw new InvalidOperationException($"Unable to parse operand '{operand}' for field '{field}' on line {lineNumber}.");
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

    private static string StripComments(string line)
    {
        var hashIndex = line.IndexOf('#');
        var semicolonIndex = line.IndexOf(';');
        var slashIndex = line.IndexOf("//", StringComparison.Ordinal);

        var first = new[] { hashIndex, semicolonIndex, slashIndex }.Where(idx => idx >= 0).DefaultIfEmpty(-1).Min();
        return first >= 0 ? line[..first] : line;
    }
}
