using SimulationEngine.Application.Services.SubCircuits;
using SimulationEngine.Cli.Handlers.IO;
using SimulationEngine.Cli.Handlers.Renderer;
using Spectre.Console;
using Spectre.Console.Cli;

namespace SimulationEngine.Cli.Commands.Database.SubCircuit;

public sealed class SubCircuitListCommand(ISubCircuitService service, IInputOutput inputOutput, IRenderer renderer) : AsyncCommand
{
    public override async Task<int> ExecuteAsync(CommandContext ctx)
    {
        var subCircuits = await service.GetAllAsync();

        renderer.DrawTable(subCircuits);

        // Optional: allow quick select to view a single item
        var pickedSubCircuit = inputOutput.SelectOrBack("Select to view or Back", subCircuits, s => $"{s.Title} ({s.Id})");
        if (pickedSubCircuit is not null)
            renderer.DrawPanel($"[bold]{Markup.Escape(pickedSubCircuit.Title)}[/]\n[grey]{pickedSubCircuit.Id}[/]", "SubCircuit");

        return 0;
    }
}
