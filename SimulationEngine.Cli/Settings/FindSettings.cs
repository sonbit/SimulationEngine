using Spectre.Console;
using Spectre.Console.Cli;

namespace SimulationEngine.Cli.Settings;

public class FindSettings : BaseIdSettings
{
    [CommandOption("--title <ID>")] public string? Title { get; set; }
    [CommandOption("-i|--interactive")] public bool Interactive { get; set; }

    public override ValidationResult Validate() => 
        Id.HasValue && Id.Value != 0 || !string.IsNullOrWhiteSpace(Title)  || Interactive
           ? ValidationResult.Success()
           : ValidationResult.Error("Provide --id, --title or use --interactive");
}