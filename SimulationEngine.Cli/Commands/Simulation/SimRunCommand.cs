using SimulationEngine.Application.Converters;
using SimulationEngine.Application.Services.SubCircuits;
using SimulationEngine.Application.Utils;
using SimulationEngine.Simulator.Core.Engine;
using Spectre.Console;
using Spectre.Console.Cli;

namespace SimulationEngine.Cli.Commands.Simulation;

public sealed class SimRunSettings : CommandSettings
{
    [CommandOption("--id <ID>")] public int Id { get; set; }
    [CommandOption("--file <PATH>")] public FileInfo? File { get; set; }
}

public sealed class SimRunCommand(ISubCircuitService service) : AsyncCommand<SimRunSettings>
{
    public override async Task<int> ExecuteAsync(CommandContext ctx, SimRunSettings s)
    {
        var subCircuit = await service.GetByIdAsync(s.Id);
        if (subCircuit is null) 
        { 
            AnsiConsole.MarkupLine("[red]Subcircuit not found[/]"); 
            return 1; 
        }

        var simulationSession = SimulationSession.Build(subCircuit);

        if (s.File is not null)
        {
            var testStrings = string.Join(Environment.NewLine, File.ReadLines(s.File.FullName));
            var testVectors = TestStringConverter.Convert(testStrings);

            foreach (var testVector in testVectors)
            {
                simulationSession.SetInputs(testVector.Inputs);
                AnsiConsole.MarkupLine($"[blue]›[/] Output: {TestStringConverter.Convert(simulationSession.GetOutputs())}");
            }

            AnsiConsole.MarkupLine("[green]Done[/]");
            return 0;
        }

        await SimListCommand.SimulatorReplAsync(simulationSession);
        return 0;
    }
}

