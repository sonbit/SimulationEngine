using Spectre.Console.Cli;

namespace SimulationEngine.Cli.Commands.Settings;

public sealed class FindByIdSettings : CommandSettings
{
    [CommandOption("--id <ID>")] public int Id { get; set; }
}