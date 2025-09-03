using SimulationEngine.Application.Interfaces;
using SimulationEngine.Domain.Models;
using SimulationEngine.Simulator.Builders;

namespace SimulationEngine.Application.Factories;

public sealed class SubCircuitFactory(ISubCircuitTemplateReader subCircuitTemplateReader)
{
    public async Task<SubCircuit> CreateInstanceAsync(int subCiruitId, CancellationToken cancellationToken = default)
    {
        var subCircuitTemplate = await subCircuitTemplateReader.LoadTemplateAsync(subCiruitId, cancellationToken);
        return SubCircuitBuilder.Build(subCircuitTemplate);
    }

    public static SubCircuit Duplicate(SubCircuit subCircuitTemplate) => SubCircuitBuilder.Build(subCircuitTemplate);
}
