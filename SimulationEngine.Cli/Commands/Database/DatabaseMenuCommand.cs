using SimulationEngine.Cli.Commands.Database.SubCircuits;
using SimulationEngine.Cli.Commands.Database.TruthTables;
using SimulationEngine.Cli.Composition;
using SimulationEngine.Cli.Extensions;
using Spectre.Console;
using Spectre.Console.Cli;
using System.ComponentModel;

namespace SimulationEngine.Cli.Commands.Database;

public sealed class DatabaseMenuCommand : AsyncCommand
{
    private readonly CommandApp _inner;

    public DatabaseMenuCommand(IServiceProvider sp)
    {
        _inner = new CommandApp(new TypeRegistrar(sp));
        _inner.Configure(cfg =>
        {
            cfg.AddBranch("subcircuits", sub =>
            {
                sub.AddCommand<SubCircuitsListCommand>("list");
                sub.AddCommand<SubCircuitsFindCommand>("find");
                sub.AddCommand<SubCircuitsShowTreeCommand>("tree");
                sub.AddCommand<SubCircuitsPopulateCommand>("populate");
            });
            cfg.AddBranch("truthtables", tt =>
            {
                tt.AddCommand<TruthTablesListCommand>("list");
                tt.AddCommand<TruthTablesFindCommand>("find");
                tt.AddCommand<TruthTablesPopulateCommand>("populate");
            });
            cfg.AddCommand<DatabaseRecreateCommand>("recreate");
        });
    }

    private enum DatabaseOption 
    { 
        SubCircuits, 
        TruthTables, 
        [Description("Recreate database")] Recreate, 
        Back 
    }

    private enum SubCircuitOption 
    {
        [Description("List all")] List,
        [Description("Find by id")] FindById,
        [Description("Find by id and show as a tree")] Tree,
        [Description("Populate database with existing unique designs")] Populate,
        Back 
    }

    private enum TruthTableOption 
    {
        [Description("List all")] List,
        [Description("Find by id")] FindById,
        [Description("Populate database with standard cell library")] Populate, 
        Back 
    }

    public override async Task<int> ExecuteAsync(CommandContext context)
    {
        while (true)
        {
            var entity = AnsiConsole.Prompt(
                new SelectionPrompt<DatabaseOption>()
                    .Title("Database Actions")
                    .AddChoices(DatabaseOption.SubCircuits, DatabaseOption.TruthTables, DatabaseOption.Recreate, DatabaseOption.Back)
                    .UseConverter(databaseOption => databaseOption.GetDescription()));

            switch (entity)
            {
                case DatabaseOption.SubCircuits:
                    await ShowSubcircuitsMenuAsync();
                    break;

                case DatabaseOption.TruthTables:
                    await ShowTruthTablesMenuAsync();
                    break;

                case DatabaseOption.Recreate:
                    await _inner.RunAsync(["recreate"]);
                    break;

                case DatabaseOption.Back:
                    return 0;
            }              
        }
    }

    private async Task ShowSubcircuitsMenuAsync()
    {
        while (true)
        {
            var action = AnsiConsole.Prompt(
                new SelectionPrompt<SubCircuitOption>()
                    .Title("[bold]SubCircuits[/]")
                    .AddChoices(SubCircuitOption.List, SubCircuitOption.FindById, SubCircuitOption.Tree, SubCircuitOption.Populate, SubCircuitOption.Back)
                    .UseConverter(subCircuitOption => subCircuitOption.GetDescription()));

            AnsiConsole.Clear();

            switch (action)
            {
                case SubCircuitOption.List:
                    await _inner.RunAsync(["subcircuits", "list", "--pick"]);
                    break;

                case SubCircuitOption.FindById:
                    await _inner.RunAsync(["subcircuits", "find", "--interactive"]);
                    break;

                case SubCircuitOption.Tree:
                    await _inner.RunAsync(["subcircuits", "tree", "--interactive"]);
                    break;

                case SubCircuitOption.Populate:
                    await _inner.RunAsync(["subcircuits", "populate"]);
                    break;

                case SubCircuitOption.Back:
                    return;
            }
        }
    }

    private async Task ShowTruthTablesMenuAsync()
    {
        while (true)
        {
            var action = AnsiConsole.Prompt(
                new SelectionPrompt<TruthTableOption>()
                    .Title("[bold]TruthTables[/]")
                    .AddChoices(TruthTableOption.List, TruthTableOption.FindById, TruthTableOption.Populate, TruthTableOption.Back)
                    .UseConverter(truthTableOption => truthTableOption.GetDescription()));

            AnsiConsole.Clear();

            switch (action)
            {
                case TruthTableOption.List:
                    await _inner.RunAsync(["truthtables", "list", "--pick"]);
                    break;

                case TruthTableOption.FindById:
                    await _inner.RunAsync(["truthtables", "find", "--interactive"]);
                    break;

                case TruthTableOption.Populate:
                    await _inner.RunAsync(["truthtables", "populate"]);
                    break;

                case TruthTableOption.Back:
                    return;
            }
        }
    }
}
