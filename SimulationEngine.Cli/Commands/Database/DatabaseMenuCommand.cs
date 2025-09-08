using SimulationEngine.Cli.Commands.Database.SubCircuit;
using SimulationEngine.Cli.Commands.Database.TruthTable;
using SimulationEngine.Cli.Composition;
using Spectre.Console;
using Spectre.Console.Cli;
using System;

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
            });
            cfg.AddBranch("truthtables", tt =>
            {
                tt.AddCommand<TruthTableListCommand>("list");
                tt.AddCommand<TruthTableFindCommand>("find");
            });
        });
    }

    enum DatabaseOption { SubCircuits, TruthTables, Back }
    enum SubCircuitOption { List, FindById, Tree, Back }
    enum TruthTableOption { List, FindById, Back }

    public override async Task<int> ExecuteAsync(CommandContext context)
    {
        while (true)
        {
            var entity = AnsiConsole.Prompt(
                new SelectionPrompt<DatabaseOption>()
                    .Title("Database")
                    .AddChoices(DatabaseOption.SubCircuits, DatabaseOption.TruthTables, DatabaseOption.Back));

            if (entity == DatabaseOption.Back) 
                return 0;

            if (entity == DatabaseOption.SubCircuits)
                await ShowSubcircuitsMenuAsync();
            else
                await ShowTruthTablesMenuAsync();
        }       
    }

    private async Task ShowSubcircuitsMenuAsync()
    {
        while (true)
        {
            var action = AnsiConsole.Prompt(
                new SelectionPrompt<SubCircuitOption>()
                    .Title("[bold]SubCircuits[/]")
                    .AddChoices(SubCircuitOption.List, SubCircuitOption.FindById, SubCircuitOption.Tree, SubCircuitOption.Back));

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
                    .AddChoices(TruthTableOption.List, TruthTableOption.FindById, TruthTableOption.Back));

            switch (action)
            {
                case TruthTableOption.List:
                    await _inner.RunAsync(["truthtables", "list", "--pick"]);
                    break;

                case TruthTableOption.FindById:
                    await _inner.RunAsync(["truthtables", "find", "--interactive"]);
                    break;

                case TruthTableOption.Back:
                    return;
            }
        }
    }
}
