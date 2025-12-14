using SimulationEngine.Application.Services.Analysis.Models;
using SimulationEngine.Domain.Models;

namespace SimulationEngine.Application.Services.Analysis;

public interface ISubcircuitAnalysisService
{
    SubcircuitGateSummary SummarizeGates(Subcircuit subcircuit);
}
