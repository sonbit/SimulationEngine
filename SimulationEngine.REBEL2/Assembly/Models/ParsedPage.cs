namespace SimulationEngine.REBEL2.Assembly.Models;

internal sealed record ParsedPage(IReadOnlyList<ParsedInstruction> Instructions, IReadOnlyDictionary<string, LabelDefinition> Labels);
