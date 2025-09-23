using SimulationEngine.Application.Services.Database;
using SimulationEngine.Cli.Handlers.InputOutput;
using System.ComponentModel;

namespace SimulationEngine.Cli.Flows.Database;

public sealed class DatabaseFlow(IInputOutput inputOutput, IDatabaseService service, SubCircuitsFlow subCircuitFlow, TruthTablesFlow truthTableFlow)
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
            var selected = await inputOutput.SelectEnumAsync<MenuOptions>("Database actions");

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
                    return;
            }
        }
    }
}