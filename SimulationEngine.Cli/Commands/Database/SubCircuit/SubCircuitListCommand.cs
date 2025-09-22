using SimulationEngine.Application.Services.SubCircuits;
using SimulationEngine.Cli.Handlers.Renderer;
using Spectre.Console.Cli;

namespace SimulationEngine.Cli.Commands.Database.SubCircuit;

public sealed class SubCircuitListCommand(ISubCircuitService service, IRenderer renderer) : AsyncCommand
{
    public override async Task<int> ExecuteAsync(CommandContext ctx)
    {
        var subCircuits = await service.GetAllAsync();

        renderer.PropertyTable(subCircuits.Select(subCircuit => new
        {
            subCircuit.Id,
            subCircuit.Title,
            Inputs = subCircuit.Inputs.Count,
            LogicGates = subCircuit.LogicGates.Count,
            Outputs = subCircuit.Outputs.Count,
            SubCircuits = subCircuit.SubCircuits.Count,
            Wires = subCircuit.Wires.Count
        }), [
            nameof(Domain.Models.SubCircuit.Id), 
            nameof(Domain.Models.SubCircuit.Title),
            nameof(Domain.Models.SubCircuit.Inputs),
            nameof(Domain.Models.SubCircuit.LogicGates),
            nameof(Domain.Models.SubCircuit.Outputs),
            nameof(Domain.Models.SubCircuit.SubCircuits),
            nameof(Domain.Models.SubCircuit.Wires)
        ]);

        return 0;
    }
}