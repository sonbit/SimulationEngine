using SimulationEngine.Cli.Commands.Database.SubCircuit;
using SimulationEngine.Cli.Commands.Database.TruthTable;
using SimulationEngine.Cli.Composition;
using Spectre.Console;
using Spectre.Console.Cli;

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
                sub.AddCommand<SubCircuitListCommand>("list");
                sub.AddCommand<SubCircuitFindCommand>("find");
                sub.AddCommand<SubCircuitShowTreeCommand>("tree");
                sub.AddCommand<SubCircuitPopulateCommand>("populate");
            });
            cfg.AddBranch("truthtables", tt =>
            {
                tt.AddCommand<TruthTableListCommand>("list");
                tt.AddCommand<TruthTableFindCommand>("find");
                tt.AddCommand<TruthTablePopulateCommand>("populate");
            });
            cfg.AddCommand<DatabaseRecreateCommand>("recreate");
        });
    }

    enum DatabaseOption { SubCircuits, TruthTables, Recreate, Back }
    enum SubCircuitOption { List, FindById, Tree, Populate, Back }
    enum TruthTableOption { List, FindById, Populate, Back }

    public override async Task<int> ExecuteAsync(CommandContext context)
    {
        while (true)
        {
            var entity = AnsiConsole.Prompt(
                new SelectionPrompt<DatabaseOption>()
                    .Title("Database")
                    .AddChoices(DatabaseOption.SubCircuits, DatabaseOption.TruthTables, DatabaseOption.Recreate, DatabaseOption.Back));

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
                    .AddChoices(SubCircuitOption.List, SubCircuitOption.FindById, SubCircuitOption.Tree, SubCircuitOption.Populate, SubCircuitOption.Back));

            switch (action)
            {
                case SubCircuitOption.List:
                    await _inner.RunAsync(["subcircuits", "list", "--pick"]);
                    break;

                case SubCircuitOption.FindById:
                    await _inner.RunAsync(["subcircuits", "find", "--interactive"]);
                    break;

                case SubCircuitOption.Tree:
                    //var id = AskGuid("Enter subcircuit id:");
                    var id = 0;
                    await _inner.RunAsync(["subcircuits", "tree", "--id", id.ToString()]);
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
                    .AddChoices(TruthTableOption.List, TruthTableOption.FindById, TruthTableOption.Populate, TruthTableOption.Back));

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
