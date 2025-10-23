using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Extensions;

namespace SimulationEngine.Simulator;

public partial class SimulationSession
{
    public byte[] GetOutputBytes() => [.. Subcircuit.Outputs.Select(GetOutputByte)];

    public string GetOutputs(bool normalize = false)
    {
        if (normalize)
            return string.Join("", GetOutputBytes());
        else
            return GetOutputsWithRadix();
    }

    public void SetInputBytes(byte[] values)
    {
        if (values.Length != Subcircuit.Inputs.Count)
            throw new ArgumentException($"Input length mismatch: expected {Subcircuit.Inputs.Count}, got {values.Length}");

        for (int i = 0; i < values.Length; i++)
            SetInputByte(Subcircuit.Inputs[i], values[i]);
    }

    public void SetInputs(string values, bool isNormalized = false)
    {
        if (values.Length != Subcircuit.Inputs.Count)
            throw new ArgumentException($"Input length mismatch: expected {Subcircuit.Inputs.Count}, got {values.Length}");

        if (isNormalized)
            SetInputBytes([.. values.Select(ch => (byte)(ch - '0'))]);
        else
            SetInputsWithRadix(values);
    }

    public string Simulate(string inputs, bool isNormalized = false)
    {
        SetInputs(inputs, isNormalized);
        return GetOutputs(isNormalized);
    }

    private byte GetOutputByte(Port port) => _netOfTerminals[port].Value;

    private string GetOutputsWithRadix()
    {
        var chars = new char[Subcircuit.Outputs.Count];

        for (int i = 0; i < Subcircuit.Outputs.Count; i++)
        {
            var port = Subcircuit.Outputs[i];
            var value = GetOutputByte(port);
            chars[i] = port.ToChar(value);
        }

        return new string(chars);
    }

    private void SetInputByte(Port port, byte value)
    {
        if (value > 2)
            throw new ArgumentOutOfRangeException(nameof(value), $"Invalid input value {value} for port {port.Title} in {Subcircuit.Title}");

        _deltaKernel.Set(_netOfTerminals[port], value);
    }

    private void SetInputsWithRadix(string values)
    {
        if (values.Length != Subcircuit.Inputs.Count)
            throw new ArgumentException($"Input length mismatch: expected {Subcircuit.Inputs.Count}, got {values.Length}");

        var bytes = new byte[values.Length];

        for (int i = 0; i < values.Length; i++)
            bytes[i] = Subcircuit.Inputs[i].ToByte(values[i]);

        SetInputBytes(bytes);
    }
}