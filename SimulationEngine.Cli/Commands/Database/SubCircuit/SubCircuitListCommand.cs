using SimulationEngine.Application.Services.SubCircuits;
using SimulationEngine.Cli.IOHandlers;
using SimulationEngine.Cli.Renderers;
using Spectre.Console;
using Spectre.Console.Cli;

namespace SimulationEngine.Cli.Commands.Database.SubCircuit;

public sealed class SubCircuitListCommand(ISubCircuitService svc, IInteraction interaction, IRenderer renderer) : AsyncCommand
{
    public override async Task<int> ExecuteAsync(CommandContext ctx)
    {
        var subCircuits = await svc.GetAllAsync();

        renderer.DrawTable(subCircuits);

        // Optional: allow quick select to view a single item
        var pickedSubCircuit = interaction.SelectOrBack("Select to view or Back", subCircuits, s => $"{s.Title} ({s.Id})");
        if (pickedSubCircuit is not null)
            renderer.DrawPanel($"[bold]{Markup.Escape(pickedSubCircuit.Title)}[/]\n[grey]{pickedSubCircuit.Id}[/]", "SubCircuit");

        return 0;
    }
}
