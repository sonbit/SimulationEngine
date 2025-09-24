using SimulationEngine.Application.Converters;
using SimulationEngine.Domain.Models;
using SimulationEngine.Simulator;
using System;
using System.Text;

namespace SimulationEngine.Infrastructure.Export.Generators;

public static class VectorStringGenerator
{
    public static string Generate(SubCircuit subCircuit)
    {
        var simulationSession = SimulationSession.Build(subCircuit);

        var sb = new StringBuilder();

        void Recurse(int index, byte[] inputValues)
        {
            if (index == subCircuit.Inputs.Count)
            {
                simulationSession.SetInputBytes(inputValues);
                var outputValues = simulationSession.GetOutputBytes();

                sb.Append(TestStringConverter.Convert(inputValues));
                sb.Append(' ');
                sb.Append(TestStringConverter.Convert(outputValues));
                sb.AppendLine();

                return;
            }

            for (byte value = 0; value < 3; value++)
            {
                inputValues[index] = value;
                Recurse(index + 1, inputValues);
            }
        }

        Recurse(0, new byte[Math.Max(1, subCircuit.Inputs.Count)]);
        return sb.ToString();
    }
}