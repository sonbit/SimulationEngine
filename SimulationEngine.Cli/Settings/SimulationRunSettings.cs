using Spectre.Console.Cli;

namespace SimulationEngine.Cli.Settings;

public sealed class SimulationRunSettings : FindSettings
{
    [CommandOption("--file <PATH>")] public FileInfo? File { get; set; }
    [CommandOption("--inputs <TEXT>")] public string? InputStrings { get; set; }
    [CommandOption("--stream")] public bool Stream { get; set; }
    [CommandOption("--normalize")] public bool Normalize { get; set; }
}