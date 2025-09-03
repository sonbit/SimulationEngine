using Microsoft.EntityFrameworkCore;
using SimulationEngine.Application.Interfaces;
using SimulationEngine.Domain.Models;
using SimulationEngine.Infrastructure.DataModel;
using System.Threading;
using System.Threading.Tasks;

namespace SimulationEngine.Infrastructure.Persistence;

public sealed class SubCircuitTemplateReader(SimulationEngineDbContext dbContext) : ISubCircuitTemplateReader
{
    public async Task<SubCircuit> LoadTemplateAsync(int subCircuitId, CancellationToken cancellationToken = default)
    {
        return await dbContext.SubCircuits
            .AsNoTracking()
            .Include(subCircuit => subCircuit.Ports)
            .Include(subCircuit => subCircuit.LogicGates)
                .ThenInclude(logicGate => logicGate.Pins)
            .Include(subCircuit => subCircuit.Wires)
            .Include(subCircuit => subCircuit.SubCircuits)
            .SingleAsync(subCircuit => subCircuit.Id == subCircuitId, cancellationToken);
    }
}
