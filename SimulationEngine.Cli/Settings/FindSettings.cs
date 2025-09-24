using Spectre.Console;
using Spectre.Console.Cli;

namespace SimulationEngine.Cli.Settings;

public class FindSettings : BaseIdSettings
{
    [CommandOption("-t|--title")] public string? Title { get; set; }
    [CommandOption("-I|--interactive")] public bool Interactive { get; set; }

    public override ValidationResult Validate() => 
        Id.HasValue && Id.Value != 0 || !string.IsNullOrWhiteSpace(Title)  || Interactive
           ? ValidationResult.Success()
           : ValidationResult.Error("Provide any of -i or --id, -t or --title, -I or --interactive");
}