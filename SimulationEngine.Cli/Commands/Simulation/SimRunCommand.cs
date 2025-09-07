using SimulationEngine.Application.Services.Interfaces;
using Spectre.Console;
using Spectre.Console.Cli;

namespace SimulationEngine.Cli.Commands.Simulation;

public sealed class SimRunSettings : CommandSettings
{
    [CommandOption("--id <ID>")] public int Id { get; set; }
    [CommandOption("--file <PATH>")] public FileInfo? File { get; set; }
}

public sealed class SimRunCommand(ISubCircuitService svc) : AsyncCommand<SimRunSettings>
{
    public override async Task<int> ExecuteAsync(CommandContext ctx, SimRunSettings s)
    {
        var sub = await svc.GetByIdAsync(s.Id);
        if (sub is null) { AnsiConsole.MarkupLine("[red]Subcircuit not found[/]"); return 1; }

        using var session = await _sim.StartAsync(sub, ctx.CancellationToken);

        if (s.File is not null)
        {
            // batch from file (or stdin if you prefer)
            foreach (var line in File.ReadLines(s.File.FullName))
                await session.FeedAsync(line);

            AnsiConsole.MarkupLine("[green]Done[/]");
            return 0;
        }

        // no file => same REPL as interactive
        await SimListCommand.SimulatorReplAsync(sub, _sim, ctx.CancellationToken);
        return 0;
    }
}

