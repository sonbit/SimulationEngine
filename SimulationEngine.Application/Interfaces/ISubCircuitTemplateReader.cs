using SimulationEngine.Domain.Models;

namespace SimulationEngine.Application.Interfaces;

public interface ISubCircuitTemplateReader
{
    Task<SubCircuit> LoadTemplateAsync(int subCircuitId, CancellationToken cancellationToken = default);
}
