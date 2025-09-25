using Spectre.Console;
using Spectre.Console.Cli;

namespace SimulationEngine.Cli.Settings;

public abstract class BaseFindSettings : CommandSettings
{
    [CommandOption("-i|--id")] public int? Id { get; set; }
    [CommandOption("-t|--title")] public string? Title { get; set; }

    public override ValidationResult Validate() 
    {
        var hasId = Id.HasValue && Id.Value != 0;
        var hasTitle = !string.IsNullOrWhiteSpace(Title);

        if (hasId && !hasTitle || !hasId && hasTitle)
            return ValidationResult.Success();

        return ValidationResult.Error("Provide either -i|--id OR -t|--title");
    }
}