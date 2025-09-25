using SimulationEngine.Cli.Flows;
using SimulationEngine.Cli.Handlers.UI;
using SimulationEngine.Cli.Settings;
using Spectre.Console.Cli;

namespace SimulationEngine.Cli.Commands.Export;

public sealed class ExportCommand(IRenderer renderer, ExportFlow flow) : AsyncCommand<ExportSettings>
{
    public override async Task<int> ExecuteAsync(CommandContext context, ExportSettings settings)
    {
        if (settings?.Id > 0)
        {
            await flow.WriteVerilogAsync(settings.Id ?? 0, settings.Testbench);
            return 0;
        }
        else if (!string.IsNullOrWhiteSpace(settings?.Title))
        {
            await flow.ExportVerilogSingleFileAsync(settings.Title, settings.Testbench);
            return 0;
        }

        renderer.DrawError("Provide either -i|--id OR -t|--title");
        return 1;
    }
}