using SimulationEngine.Application.Services.TruthTables;
using SimulationEngine.Cli.Commands.Settings;
using SimulationEngine.Cli.Handlers.IO;
using SimulationEngine.Cli.Handlers.Renderer;
using Spectre.Console;
using Spectre.Console.Cli;

namespace SimulationEngine.Cli.Commands.Database.TruthTable;

public sealed class TruthTableFindCommand(ITruthTableService service, IRenderer renderer, IInputOutput inputOutput) : AsyncCommand<FindByIdSettings>
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

        var truthTable = await service.GetByIdAsync(id);
        if (truthTable is null) 
        {
            renderer.DrawError("Not found");
            return 1; 
        }

        AnsiConsole.Write(new Panel($"[bold]{Markup.Escape(truthTable.HeptaIndex)}[/]\n[grey]{truthTable.Id}[/]").Header("TruthTable"));
        return 2;
    }
}
