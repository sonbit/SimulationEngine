using SimulationEngine.Cli.Flows;
using SimulationEngine.Cli.Handlers.UI;
using SimulationEngine.Cli.Settings;
using Spectre.Console.Cli;

namespace SimulationEngine.Cli.Commands.Export;

public sealed class EmitCommand(IRenderer renderer, EmitFlow flow) : AsyncCommand<EmitSettings>
{
    public override async Task<int> ExecuteAsync(CommandContext context, EmitSettings settings)
    {
        if (settings?.Id > 0)
        {
            await flow.EmitVerilog(settings.Id ?? 0, settings.EmitKind);
            return 0;
        }
        else if (!string.IsNullOrWhiteSpace(settings?.Title))
        {
            await flow.EmitVerilog(settings.Title, settings.EmitKind);
            return 0;
        }

        renderer.DrawError("Provide either -i|--id OR -t|--title");
        return 1;
    }
}