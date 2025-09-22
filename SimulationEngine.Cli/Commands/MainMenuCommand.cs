using SimulationEngine.Cli.Commands.Database;
using SimulationEngine.Cli.Commands.Database.SubCircuits;
using SimulationEngine.Cli.Commands.Database.TruthTables;
using SimulationEngine.Cli.Commands.Simulation;
using SimulationEngine.Cli.Composition;
using SimulationEngine.Cli.Extensions;
using Spectre.Console;
using Spectre.Console.Cli;
using System.ComponentModel;

namespace SimulationEngine.Cli.Commands;

public sealed class MainMenuCommand : AsyncCommand
{
    private readonly CommandApp _inner;

    public MainMenuCommand(IServiceProvider sp)
    {
        _inner = new CommandApp(new TypeRegistrar(sp));
        _inner.Configure(cfg =>
        {
            cfg.AddBranch("simulation", sim =>
            {
                sim.AddCommand<SimListCommand>("list");
                sim.AddCommand<SimRunCommand>("run");
            });
            cfg.AddBranch("db", db =>
            {
                db.AddCommand<DatabaseMenuCommand>("menu");

                db.AddBranch("subcircuits", sub =>
                {
                    sub.AddCommand<SubCircuitsListCommand>("list");
                    sub.AddCommand<SubCircuitsFindCommand>("find");
                    sub.AddCommand<SubCircuitsShowTreeCommand>("tree");
                    sub.AddCommand<SubCircuitsPopulateCommand>("populate");
                });
                db.AddBranch("truthtables", tt =>
                {
                    tt.AddCommand<TruthTablesListCommand>("list");
                    tt.AddCommand<TruthTablesFindCommand>("find");
                    tt.AddCommand<TruthTablesPopulateCommand>("populdate");
                });
            });
        });
    }

    private enum MainChoice 
    { 
        [Description("Simulation")] Simulation,
        [Description("Database options")] Database,
        [Description("Exit application")] Exit 
    }

    public override async Task<int> ExecuteAsync(CommandContext context)
    {
        while (true)
        {
            var choice = AnsiConsole.Prompt(
                new SelectionPrompt<MainChoice>()
                    .Title("Simulation Engine Main Menu")
                    .AddChoices(MainChoice.Simulation, MainChoice.Database, MainChoice.Exit)
                    .UseConverter(mainChoice => mainChoice.GetDescription()));

            switch (choice)
            {
                case MainChoice.Simulation:
                    await _inner.RunAsync(["simulation", "list"]);
                    break;
                case MainChoice.Database:
                    await _inner.RunAsync(["db", "menu"]);
                    break;
                case MainChoice.Exit:
                    return 0;
            }
        }
    }
}
