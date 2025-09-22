using SimulationEngine.Application.Services.SubCircuits;
using SimulationEngine.Cli.Commands.Settings;
using SimulationEngine.Cli.Handlers.InputOutput;
using SimulationEngine.Cli.Handlers.Renderer;
using Spectre.Console.Cli;

namespace SimulationEngine.Cli.Commands.Database.SubCircuit;

public sealed class SubCircuitFindCommand(ISubCircuitService service, IInputOutput inputOutput, IRenderer renderer) : AsyncCommand<FindByIdSettings>
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
            (nameof(Domain.Models.SubCircuit.Id), subCircuit.Id),
            (nameof(Domain.Models.SubCircuit.Title), subCircuit.Title),
            (nameof(Domain.Models.SubCircuit.Hash), subCircuit.Hash),
            (nameof(Domain.Models.SubCircuit.Inputs), subCircuit.Inputs.Count),
            (nameof(Domain.Models.SubCircuit.LogicGates), subCircuit.LogicGates.Count),
            (nameof(Domain.Models.SubCircuit.Outputs), subCircuit.Outputs.Count),
            (nameof(Domain.Models.SubCircuit.SubCircuits), subCircuit.SubCircuits.Count),
            (nameof(Domain.Models.SubCircuit.Wires), subCircuit.Wires.Count),
        ]);

        return 2;
    }
}
