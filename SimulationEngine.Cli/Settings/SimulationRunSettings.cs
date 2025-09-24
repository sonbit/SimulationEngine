using Spectre.Console.Cli;

namespace SimulationEngine.Cli.Settings;

public sealed class SimulationRunSettings : FindSettings
{
    [CommandOption("-f|--file")] public FileInfo? File { get; set; }
    [CommandOption("-p|--inputs")] public string? InputString { get; set; }
    [CommandArgument(0, "[inputs]")] public string[] InputVectors { get; set; } = [];
    [CommandOption("-s|--stream")] public bool Stream { get; set; }
    [CommandOption("-n|--normalize")] public bool Normalize { get; set; }
    [CommandOption("-b|--benchmark")] public bool Benchmark { get; set; }
}