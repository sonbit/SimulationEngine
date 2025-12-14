using SimulationEngine.Application.Services.Analysis.Models;
using SimulationEngine.Domain.Converters;
using SimulationEngine.Domain.Models;

namespace SimulationEngine.Application.Services.Analysis;

public sealed class SubcircuitAnalysisService : ISubcircuitAnalysisService
{
    public SubcircuitGateSummary SummarizeGates(Subcircuit subcircuit)
    {
        ArgumentNullException.ThrowIfNull(subcircuit);

        var byHeptaIndex = new Dictionary<string, int>(StringComparer.Ordinal);
        var byArity = new Dictionary<int, int>();

        void Walk(Subcircuit current)
        {
            foreach (var logicGate in current.LogicGates)
            {
                var heptaIndex = logicGate.TruthTable.HeptaIndex;
                if (string.IsNullOrWhiteSpace(heptaIndex))
                    continue;

                if (!byHeptaIndex.TryGetValue(heptaIndex, out var heptaCount))
                    heptaCount = 0;
                byHeptaIndex[heptaIndex] = heptaCount + 1;

                var arity = HeptaIndexConverter.GetArity(heptaIndex);
                if (!byArity.TryGetValue(arity, out var arityCount))
                    arityCount = 0;
                byArity[arity] = arityCount + 1;
            }

            foreach (var child in current.Subcircuits)
                Walk(child);
        }

        Walk(subcircuit);

        return new SubcircuitGateSummary(byHeptaIndex.Values.Sum(), byHeptaIndex, byArity);
    }
}
