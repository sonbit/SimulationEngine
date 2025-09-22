using SimulationEngine.Application.Services.SubCircuits;
using SimulationEngine.Cli.Handlers.Renderer;
using SimulationEngine.Domain.Models;
using Spectre.Console.Cli;

namespace SimulationEngine.Cli.Commands.Database.SubCircuits;

public sealed class SubCircuitsListCommand(ISubCircuitService service, IRenderer renderer) : AsyncCommand
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
            nameof(SubCircuit.Id), 
            nameof(SubCircuit.Title),
            nameof(SubCircuit.Inputs),
            nameof(SubCircuit.LogicGates),
            nameof(SubCircuit.Outputs),
            nameof(SubCircuit.SubCircuits),
            nameof(SubCircuit.Wires)
        ]);

        return 0;
    }
}