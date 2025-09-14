using SimulationEngine.Application.Services.SubCircuits;
using SimulationEngine.Cli.Commands.Settings;
using SimulationEngine.Cli.Handlers.Renderer;
using Spectre.Console;
using Spectre.Console.Cli;

namespace SimulationEngine.Cli.Commands.Database.SubCircuit;

public sealed class SubCircuitFindCommand(ISubCircuitService service, IRenderer renderer) : AsyncCommand<FindByIdSettings>
{
    public override async Task<int> ExecuteAsync(CommandContext ctx, FindByIdSettings s)
    {
        var subCircuit = await service.GetByIdAsync(s.Id);
        if (subCircuit is null) 
        {
            renderer.DrawError("Not found");
            return 1; 
        }

        AnsiConsole.Write(new Panel($"[bold]{Markup.Escape(subCircuit.Title)}[/]\n[grey]{subCircuit.Id}[/]").Header("SubCircuit").RoundedBorder());
        return 0;
    }
}
