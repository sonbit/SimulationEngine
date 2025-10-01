using Spectre.Console.Cli;

namespace SimulationEngine.Cli.Settings;

public sealed class ExportSettings : BaseFindSettings
{
    [CommandOption("-o|--out <PATH>")] public string? OutputPath { get; set; }
    [CommandOption("-z|--zip")] public bool Zip { get; set; }
    [CommandOption("-x")] public bool IncludeTop { get; set; }
}