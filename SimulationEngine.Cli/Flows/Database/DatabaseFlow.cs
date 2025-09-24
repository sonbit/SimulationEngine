using SimulationEngine.Application.Services.Database;
using SimulationEngine.Cli.Handlers.IO;
using SimulationEngine.Cli.Handlers.UI;
using System.ComponentModel;

namespace SimulationEngine.Cli.Flows.Database;

public sealed class DatabaseFlow(IPrompter prompter, IRenderer renderer, IDatabaseService service, SubCircuitsFlow subCircuitFlow, TruthTablesFlow truthTableFlow)
{
    private enum MenuOptions
    {
        SubCircuits,
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
                case MenuOptions.SubCircuits:
                    await subCircuitFlow.RunMenuAsync();
                    break;

                case MenuOptions.TruthTables:
                    await truthTableFlow.RunMenuAsync();
                    break;

                case MenuOptions.RecreateDatabase:
                    await service.EnsureDatabaseRecreatedAsync();
                    break;

                case MenuOptions.Back:
                    renderer.Clear();
                    return;
            }
        }
    }
}