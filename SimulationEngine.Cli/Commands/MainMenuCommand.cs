using SimulationEngine.Cli.Commands.Database;
using SimulationEngine.Cli.Commands.Database.SubCircuit;
using SimulationEngine.Cli.Commands.Database.TruthTable;
using SimulationEngine.Cli.Commands.Simulation;
using SimulationEngine.Cli.Composition;
using Spectre.Console;
using Spectre.Console.Cli;

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
                    sub.AddCommand<SubCircuitListCommand>("list");
                    sub.AddCommand<SubCircuitFindCommand>("find");
                    sub.AddCommand<SubCircuitShowTreeCommand>("tree");
                });
                db.AddBranch("truthtables", tt =>
                {
                    tt.AddCommand<TruthTableListCommand>("list");
                    tt.AddCommand<TruthTableFindCommand>("find");
                });
            });
        });
    }

    private enum MainChoice { Simulation, Database, Exit }

    public override async Task<int> ExecuteAsync(CommandContext context)
    {
        while (true)
        {
            var choice = AnsiConsole.Prompt(
                new SelectionPrompt<MainChoice>()
                    .Title("Main Menu")
                    .AddChoices(MainChoice.Simulation, MainChoice.Database, MainChoice.Exit));

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
