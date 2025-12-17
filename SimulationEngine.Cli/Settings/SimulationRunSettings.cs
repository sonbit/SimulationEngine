using Spectre.Console;
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
    [CommandOption("--tests")] public bool UseTests { get; set; }
    [CommandOption("--iterations")] public int Iterations { get; set; } = 10;
    [CommandOption("-x|--copies")] public int Copies { get; set; } = 1;

    public override ValidationResult Validate()
    {
        var validation = base.Validate();
        if (!validation.Successful)
            return validation;

        if (Copies < 1)
            return ValidationResult.Error("Copies must be at least 1.");

        if (Iterations < 1)
            return ValidationResult.Error("Iterations must be at least 1.");

        if (UseTests && (File is not null || InputString is not null || (InputVectors?.Length ?? 0) > 0 || Stream))
            return ValidationResult.Error("--tests cannot be combined with file, stream, or inline inputs.");

        return ValidationResult.Success();
    }
}
