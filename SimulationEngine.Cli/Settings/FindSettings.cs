using Spectre.Console;
using Spectre.Console.Cli;

namespace SimulationEngine.Cli.Settings;

public class FindSettings : BaseFindSettings
{
    [CommandOption("-I|--interactive")] public bool Interactive { get; set; }

    public override ValidationResult Validate()
    {
        var hasId = Id.HasValue && Id.Value != 0;
        var hasTitle = !string.IsNullOrWhiteSpace(Title);

        if (hasId && !hasTitle || !hasId && hasTitle || Interactive)
            return ValidationResult.Success();

        return ValidationResult.Error("Provide either -i|--id OR -t|--title OR -I|--interactive");
    }
}