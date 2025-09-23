using SimulationEngine.Cli.Handlers.Renderer;
using SimulationEngine.Domain.Models;

namespace SimulationEngine.Cli.Flows.Shared;

public static class SimulationEntry
{
    public static async Task<int> SimulateAsync(SubCircuit subCircuit, IRenderer renderer, FileInfo? fileInfo = null, bool normalize = false)
    {
        if (fileInfo is null)
        {
            await SimulationRepl.ReplAsync(subCircuit, renderer, normalize);
            return 0;
        }

        return SimulationFile.ReadFile(subCircuit, fileInfo, renderer, normalize);
    }
}