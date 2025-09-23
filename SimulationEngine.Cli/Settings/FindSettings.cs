using Spectre.Console;
using Spectre.Console.Cli;

namespace SimulationEngine.Cli.Settings;

public sealed class FindSettings : BaseIdSettings
{
    [CommandOption("-i|--interactive")] public bool Interactive { get; set; }

    public override ValidationResult Validate() => (Interactive || (Id.HasValue && Id.Value != 0))
           ? ValidationResult.Success()
           : ValidationResult.Error("Provide --id or use --interactive.");
}