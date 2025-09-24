using SimulationEngine.Cli.UI;
using SimulationEngine.Designs;
using SimulationEngine.Domain.Converters;
using SimulationEngine.Domain.Models;
using SimulationEngine.Simulator;
using System.Diagnostics;

namespace SimulationEngine.Cli.Simulation;

public static class SimulationTest
{
    public static void Simulate(SubCircuit subCircuit, IRenderer renderer)
    {
        var type = typeof(StandardCellLibrary).Assembly
            .GetTypes()
            .FirstOrDefault(type => typeof(SubCircuit).IsAssignableFrom(type) && type.Name.Contains(subCircuit.Title));

        if (type == null || (SubCircuit?)Activator.CreateInstance(type) is not SubCircuit derivedSubCircuit)
        {
            renderer.DrawError($"Could not find type for subcircuit {subCircuit.Title}");
            return;
        }

        var testString = derivedSubCircuit.GetTestString();
        if (string.IsNullOrWhiteSpace(testString))
        {
            renderer.DrawError($"No tests defined for subcircuit {subCircuit.Title}");
            return;
        }

        renderer.Clear();

        Simulate(subCircuit, testString, renderer);
    }

    private static void Simulate(SubCircuit subCircuit, string testString, IRenderer renderer)
    {
        var simulationSession = SimulationSession.Build(subCircuit);
        var allPassed = true;
        var lineNumber = 1;
        var evaluationStrings = new List<TestResult>();

        var stopWatch = Stopwatch.StartNew();

        foreach (var (inputs, expectedOutputs) in TestStringConverter.GetInputOutputPairs(testString))
        {
            var outputs = simulationSession.Simulate(inputs);
            if (outputs.CompareTo(expectedOutputs) != 0)
                allPassed = false;
            evaluationStrings.Add(TestStringConverter.GetResult(lineNumber, inputs, expectedOutputs, outputs, outputs.CompareTo(expectedOutputs) == 0));
            lineNumber++;
        }

        stopWatch.Stop();

        renderer.DrawTableFromPropertiesWithColumnNames(evaluationStrings
            .Select(evaluationString =>
            {
                return new
                {
                    No = evaluationString.LineNumber,
                    evaluationString.Inputs,
                    Expected = evaluationString.ExpectedOutputs,
                    evaluationString.Outputs,
                    Eq = evaluationString.IsEqual,
                };
            }),
            false,
            [
                "No",
                "Inputs",
                "Expected",
                "Outputs",
                "Eq"
            ]
        );

        if (allPassed)
            renderer.DrawLine($"[green]All tests passed for {subCircuit.Title}[/]");
        else
            renderer.DrawLine($"[red]Some tests failed for {subCircuit.Title}[/]");

        renderer.DrawLine($"Elapsed time: {stopWatch.Elapsed}");
    }
}