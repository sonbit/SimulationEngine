using SimulationEngine.Cli.Handlers.Renderer;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Extensions;
using SimulationEngine.Domain.Models.Metadata.Enums;

namespace SimulationEngine.Cli.Flows.Shared;

public static class SimulationUtils
{
    public static HashSet<char>[] GetAllowedValuesPerInput(SubCircuit subCircuit)
    {
        return [.. subCircuit.Inputs.Select(port =>
        {
            var radix = port.GetRadix();

            return new HashSet<char>(
                (radix == Radix.Binary || radix == Radix.BinarySigned)
                    ? ['0', '1']
                    : radix == Radix.TernaryBalanced
                        ? ['-', '0', '+']
                        : ['0', '1', '2']);
        })];
    }

    public static byte[] GetInputsAsByteArray(string input) => [.. input.Select(c => (byte)(c - '0'))];

    public static string GetOutputsAsString(byte[] outputs) => string.Concat(outputs);
}