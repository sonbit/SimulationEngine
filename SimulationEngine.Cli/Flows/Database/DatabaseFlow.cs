using SimulationEngine.Application.Services.Database;
using SimulationEngine.Cli.Handlers.IO;
using SimulationEngine.Cli.Handlers.UI;
using System.ComponentModel;

namespace SimulationEngine.Cli.Flows.Database;

public sealed class DatabaseFlow(IPrompter prompter, IRenderer renderer, IDatabaseService service, SubcircuitsFlow subcircuitFlow, TruthTablesFlow truthTableFlow)
{
    private enum MenuOptions
    {
        Subcircuits,
        TruthTables,
        [Description("Recreate the database")] RecreateDatabase,
        Back
    }

    public async Task RunMenuAsync()
    {
        while (true)
        {
            var selected = await prompter.SelectEnumAsync<MenuOptions>("[bold]Database actions[/]");

            switch (selected)
            {
                case MenuOptions.Subcircuits:
                    await subcircuitFlow.RunMenuAsync();
                    break;

                case MenuOptions.TruthTables:
                    await truthTableFlow.RunMenuAsync();
                    break;

                case MenuOptions.RecreateDatabase:
                    await DatabaseRecreateAsync();
                    break;

                case MenuOptions.Back:
                    renderer.Clear();
                    return;
            }
        }
    }

    public async Task DatabaseRecreateAsync() => 
        await service.EnsureDatabaseRecreatedAsync();
}