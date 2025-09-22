using SimulationEngine.Application.Services.SubCircuits;
using SimulationEngine.Cli.Commands.Settings;
using SimulationEngine.Cli.Handlers.InputOutput;
using SimulationEngine.Cli.Handlers.Renderer;
using SimulationEngine.Domain.Models;
using Spectre.Console.Cli;

namespace SimulationEngine.Cli.Commands.Database.SubCircuits;

public sealed class SubCircuitsFindCommand(ISubCircuitService service, IInputOutput inputOutput, IRenderer renderer) : AsyncCommand<FindByIdSettings>
{
    public override async Task<int> ExecuteAsync(CommandContext ctx, FindByIdSettings s)
    {
        var id = s.Id;

        if (id == 0 && int.TryParse(await inputOutput.PromptValidateAsync("Id"), out var promptId))
            id = promptId;

        if (id == 0)
        {
            renderer.DrawError("Invalid id");
            return 1;
        }

        var subCircuit = await service.GetAsync(id);
        if (subCircuit is null)
        {
            renderer.DrawError($"SubCircuit with id {id} was not found");
            return 1;
        }

        renderer.Clear();

        renderer.NameValueTable(
        [
            (nameof(SubCircuit.Id), subCircuit.Id),
            (nameof(SubCircuit.Title), subCircuit.Title),
            (nameof(SubCircuit.Hash), subCircuit.Hash),
            (nameof(SubCircuit.Inputs), subCircuit.Inputs.Count),
            (nameof(SubCircuit.LogicGates), subCircuit.LogicGates.Count),
            (nameof(SubCircuit.Outputs), subCircuit.Outputs.Count),
            (nameof(SubCircuit.SubCircuits), subCircuit.SubCircuits.Count),
            (nameof(SubCircuit.Wires), subCircuit.Wires.Count),
        ]);

        return 2;
    }
}
