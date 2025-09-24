using SimulationEngine.Cli.Flows.Database;
using SimulationEngine.Cli.Flows.Simulation;
using SimulationEngine.Cli.Handlers.IO;
using Spectre.Console.Cli;
using System.ComponentModel;

namespace SimulationEngine.Cli.Commands;

public sealed class MainMenuCommand(IPrompter prompter, DatabaseFlow databaseFlow, SimulationFlow simulationFlow) : AsyncCommand
{
    private enum MenuOptions 
    { 
        [Description("Simulate subcircuit")] Simulation,
        [Description("Database options")] Database,
        [Description("Exit application")] Exit 
    }

    public override async Task<int> ExecuteAsync(CommandContext context)
    {
        while (true)
        {
            switch (await prompter.SelectEnumAsync<MenuOptions>("[bold]Simulation Engine Main Menu[/]"))
            {
                case MenuOptions.Simulation:
                    await simulationFlow.RunMenuAsync();
                    break;

                case MenuOptions.Database:
                    await databaseFlow.RunMenuAsync();
                    break;

                case MenuOptions.Exit:
                    return 0;
            }
        }
    }
}