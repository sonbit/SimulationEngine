using Spectre.Console;
using Spectre.Console.Cli;

namespace SimulationEngine.Cli.Settings;

public sealed class ExportSettings : BaseFindSettings
{
    [CommandOption("-o|--out <PATH>")] public string? OutPath { get; set; }
    [CommandOption("-z|--zip")] public bool Zip { get; set; }
    [CommandOption("-S|--stdout")] public bool StdOut { get; set; }
    [CommandOption("--tb")] public bool Testbench { get; set; }

    public override ValidationResult Validate()
    {
        base.Validate();

        if (StdOut && (Zip || !string.IsNullOrWhiteSpace(OutPath)))
            return ValidationResult.Error("Provide either -s|--stdout OR -z|--zip AND/OR -o|--out.");

        return ValidationResult.Success();
    }
}