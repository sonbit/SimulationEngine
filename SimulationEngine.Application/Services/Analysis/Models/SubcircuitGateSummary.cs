namespace SimulationEngine.Application.Services.Analysis.Models;

public sealed class SubcircuitGateSummary(
    int totalGates,
    IReadOnlyDictionary<string, int> byHeptaIndex,
    IReadOnlyDictionary<int, int> byArity)
{
    public int TotalGates { get; } = totalGates;
    public IReadOnlyDictionary<string, int> ByHeptaIndex { get; } = byHeptaIndex;
    public IReadOnlyDictionary<int, int> ByArity { get; } = byArity;
}
