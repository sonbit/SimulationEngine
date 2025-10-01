using SimulationEngine.Cli.Settings.Enums;
using Spectre.Console.Cli;

namespace SimulationEngine.Cli.Settings;

public sealed class EmitSettings : BaseFindSettings
{
    [CommandOption("-k")] public EmitKind EmitKind { get; set; } = EmitKind.Verilog;
}