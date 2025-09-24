using Spectre.Console;
using Spectre.Console.Cli;

namespace SimulationEngine.Cli.Settings;

public abstract class BaseIdSettings : CommandSettings
{
    [CommandOption("-i|--id")] public int? Id { get; set; }

    public override ValidationResult Validate() => Id.HasValue && Id.Value != 0
        ? ValidationResult.Success() 
        : ValidationResult.Error("Missing -i or --id");
}