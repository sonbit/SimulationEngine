namespace SimulationEngine.REBEL2.Assembly.Models;

internal sealed record ParsedInstruction(int LineNumber, string Text, IReadOnlyList<string> Parts);
