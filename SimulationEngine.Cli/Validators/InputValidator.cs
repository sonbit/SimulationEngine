using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Extensions;
using SimulationEngine.Domain.Models.Metadata.Enums;

namespace SimulationEngine.Cli.Validators;

public static class InputValidator
{
    public static HashSet<char>[] GetAllowedValuesPerInput(Subcircuit subcircuit)
    {
        return [.. subcircuit.Inputs.Select(port =>
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

    public static string? Validate(Subcircuit subcircuit, char inputChar, int index, bool normalize, HashSet<char>[] allowedValuesPerInput)
    {
        if (normalize && !"012".Contains(inputChar))
            return $"Input {index + 1} expects unbalanced ternary values (0, 1, 2)";

        if (!normalize && !allowedValuesPerInput[index].Contains(inputChar))
            return $"Input {index + 1} expects {GetInputRadix(subcircuit, index)} values ({GetAllowedRadixValues(allowedValuesPerInput[index])})";

        return null;
    }

    public static string? Validate(Subcircuit subcircuit, string inputString, bool normalize, HashSet<char>[] allowedValuesPerInput)
    {
        if (inputString.Length != subcircuit.Inputs.Count)
            return $"Inputs length mismatch (Got {inputString.Length}, expected {subcircuit.Inputs.Count})";

        foreach (var (inputChar, index) in inputString.Select((inputChar, index) => (inputChar, index)))
        {
            var validationErrorMessage = Validate(subcircuit, inputChar, index, normalize, allowedValuesPerInput);
            if (validationErrorMessage != null)
                return validationErrorMessage;
        }

        return null;
    }

    private static string GetInputRadix(Subcircuit subcircuit, int index) =>
        $"{subcircuit.Inputs[index].GetRadix().GetDescription()}";

    private static string GetAllowedRadixValues(HashSet<char> allowedValuesForInput) =>
        $"{string.Join(", ", allowedValuesForInput.Select(ch => ch.ToString()))}";
}