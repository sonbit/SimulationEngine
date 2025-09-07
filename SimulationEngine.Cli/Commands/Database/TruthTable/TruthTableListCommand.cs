using SimulationEngine.Application.Services.Interfaces;
using Spectre.Console;
using Spectre.Console.Cli;

namespace SimulationEngine.Cli.Commands.Database.TruthTable;

public sealed class TruthTableListCommand(ITruthTableService svc) : AsyncCommand
{
    public override async Task<int> ExecuteAsync(CommandContext ctx)
    {
        var all = await svc.GetAllAsync();
        var t = new Table().RoundedBorder().Expand().Title("TruthTables");
        t.AddColumn("Id"); t.AddColumn("HeptaIndex");
        foreach (var x in all) t.AddRow($"{x.Id}", Markup.Escape(x.HeptaIndex));
        AnsiConsole.Write(t);
        return 0;
    }
}
