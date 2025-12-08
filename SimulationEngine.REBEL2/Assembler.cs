namespace SimulationEngine.REBEL2;

public static class Assembler
{
    private const string DefaultField = "--";
    private const string DefaultPaddingInstruction = "ADDi x0, x-0, 00"; // Write zero into hardwired zero register: safe NOP
    private static readonly char[] ArgumentSeparators = [' ', '\t', ','];
    private static readonly string[] AddressSpace = ["--", "-0", "-+", "0-", "00", "0+", "+-", "+0", "++"];
    private static readonly string[] NewLineSeparators = ["\r\n", "\n", "\r"];
    private const int PageInstructionCount = 9;

    private enum Operands
    {
        RD1,
        RD2,
        RS1,
        RS2,
        IMM
    }

    private sealed record InstructionDefinition(
        string Opcode,
        IReadOnlyList<Operands> OperandOrder,
        IReadOnlyDictionary<Operands, string>? FieldDefaults = null);

    // Adjust these definitions as new instructions are added or operand layouts change.
    private static readonly Dictionary<string, InstructionDefinition> InstructionSet = new(StringComparer.OrdinalIgnoreCase)
    {
        { "ADD",   new InstructionDefinition("--", [Operands.RD1, Operands.RS1, Operands.RS2]) },
        { "ADDi",  new InstructionDefinition("-0", [Operands.RD1, Operands.RS1, Operands.IMM]) },
        { "ADDi2", new InstructionDefinition("-+", [Operands.RD1, Operands.RD2, Operands.IMM]) },

        { "MUDI",  new InstructionDefinition("0-", [Operands.RD1, Operands.RS1, Operands.RS2]) },
        { "MIMA",  new InstructionDefinition("00", [Operands.RD1, Operands.RS1, Operands.RS2]) },
        { "SHI",   new InstructionDefinition("0+", [Operands.RD1, Operands.RS1, Operands.IMM]) },

        { "COMP",  new InstructionDefinition("+-", [Operands.RD1, Operands.RS1, Operands.RS2]) },
        { "BCEG",  new InstructionDefinition("+0", [Operands.RD1, Operands.RS1, Operands.IMM]) },
        { "PCO",   new InstructionDefinition("++", [Operands.RD1, Operands.RS1, Operands.IMM]) },
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

        return [.. instructions.Select(inst => Translate(inst.text, labelDictionary, inst.lineNumber))];
    }

    /// <summary>
    /// Assemble a page and pad with NOP-like instructions to fill all 9 slots.
    /// </summary>
    public static IReadOnlyList<string> AssemblePage(string assembly, string? padInstruction = null)
    {
        var program = Assemble(assembly);
        if (program.Count == AddressSpace.Length)
            return program;

        var pad = Translate(padInstruction ?? DefaultPaddingInstruction);
        var padded = new List<string>(AddressSpace.Length);
        padded.AddRange(program);
        while (padded.Count < AddressSpace.Length)
            padded.Add(pad);
        return padded;
    }

    /// <summary>
    /// Build the full input vector sequence for one or more ROM pages:
    ///  - For each page, load instructions with WrInst=1, clock toggling each row.
    ///  - Then execute the page once by clocking through all 9 addresses with WrInst=0.
    /// </summary>
    /// <param name="pageAssemblies">Assembly strings, one per page.</param>
    /// <param name="padPages">If true, short pages are padded to 9 slots with a NOP-like instruction.</param>
    /// <returns>Lines of 12 symbols (Clk, WrInst, 10-trit word) ready for TestStringConverter.</returns>
    public static IReadOnlyList<string> BuildInputSequence(IEnumerable<string> pageAssemblies, bool padPages = true)
    {
        var sequence = new List<string>();

        foreach (var pageAssembly in pageAssemblies)
        {
            var page = padPages ? AssemblePage(pageAssembly) : Assemble(pageAssembly);
            if (page.Count != PageInstructionCount)
                throw new InvalidOperationException($"Page must contain exactly {PageInstructionCount} instructions when padding is disabled.");

            // Program ROM: WrInst=1, toggle Clk for each write.
            foreach (var instruction in page)
            {
                sequence.Add(FormatInputVector('0', '1', instruction));
                sequence.Add(FormatInputVector('1', '1', instruction));
            }

            // Execute page once: WrInst=0, 9 addresses with clock toggling.
            for (int i = 0; i < PageInstructionCount; i++)
            {
                sequence.Add(FormatInputVector('0', '0', new string('0', 10)));
                sequence.Add(FormatInputVector('1', '0', new string('0', 10)));
            }
        }

        return sequence;
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

        var fields = new Dictionary<Operands, string>
        {
            { Operands.RS1, DefaultField },
            { Operands.RS2, DefaultField },
            { Operands.RD1, DefaultField },
            { Operands.RD2, DefaultField },
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
            var targetField = operandTarget == Operands.IMM ? Operands.RS2 : operandTarget;

            if (fields[targetField] != DefaultField && fields[targetField] != value)
                throw new InvalidOperationException($"Field '{targetField}' already set when parsing operand {i + 1} on line {lineNumber}.");

            fields[targetField] = value;
        }

        return string.Concat(definition.Opcode, fields[Operands.RS1], fields[Operands.RS2], fields[Operands.RD1], fields[Operands.RD2]);
    }

    private static string ParseOperand(string operand, Operands field, IReadOnlyDictionary<string, string> labels, int lineNumber)
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

        throw new InvalidOperationException(
            $"Unable to parse operand '{operand}' for field '{field}' on line {lineNumber}. If this is a label, it must be defined within the same 9-instruction ROM page.");
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

    private static string FormatInputVector(char clk, char wrInst, string tenTritWord)
    {
        if (tenTritWord.Length != 10)
            throw new InvalidOperationException($"Instruction must be 10 trits long, got {tenTritWord.Length}.");

        return string.Concat(clk, wrInst, tenTritWord);
    }
}
