namespace SimulationEngine.REBEL2.Assembly.Models;

internal sealed record InstructionPattern(
    string Mnemonic,
    string Opcode,
    IReadOnlyList<string> AssemblyOperands,
    IReadOnlyDictionary<string, string>? Defaults = null);
