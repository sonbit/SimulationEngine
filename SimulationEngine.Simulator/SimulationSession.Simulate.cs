using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Extensions;
using SimulationEngine.Simulator.Models;

namespace SimulationEngine.Simulator;

public partial class SimulationSession
{
    public byte[] GetOutputBytes()
    {
        var outputNets = _rootProbe.OutputNets;
        var bytes = new byte[outputNets.Length];

        for (var i = 0; i < outputNets.Length; i++)
            bytes[i] = outputNets[i].Value;

        return bytes;
    }

    public string GetOutputs(bool normalize = false)
    {
        if (normalize)
            return string.Join("", GetOutputBytes());
        else
            return GetPortsWithRadix(_rootProbe.OutputPorts, _rootProbe.OutputNets);
    }

    public void SetInputBytes(byte[] values)
    {
        var inputNets = _rootProbe.InputNets;
        if (values.Length != inputNets.Length)
            throw new ArgumentException($"Input length mismatch: expected {inputNets.Length}, got {values.Length}");

        for (int i = 0; i < values.Length; i++)
            SetInputNet(inputNets[i], values[i], _rootProbe.InputPorts[i].Title);
    }

    public void SetInputs(string values, bool isNormalized = false)
    {
        var inputPorts = _rootProbe.InputPorts;
        if (values.Length != inputPorts.Length)
            throw new ArgumentException($"Input length mismatch: expected {inputPorts.Length}, got {values.Length}");

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

    public string GetInputs(Subcircuit subcircuit) => GetInputsWithRadix(subcircuit);

    public string GetOutputs(Subcircuit subcircuit) => GetOutputsWithRadix(subcircuit);

    private string GetInputsWithRadix(Subcircuit subcircuit)
    {
        if (_probeBySubcircuit.TryGetValue(subcircuit, out var probe))
            return GetPortsWithRadix(probe.InputPorts, probe.InputNets);

        var inputPorts = subcircuit.Inputs;
        var chars = new char[inputPorts.Count];

        for (int i = 0; i < inputPorts.Count; i++)
        {
            var port = inputPorts[i];
            var value = GetPortByte(port);
            chars[i] = port.ToChar(value);
        }

        return new string(chars);
    }

    private byte GetPortByte(Port port) => _netOfTerminals[port].Value;

    private string GetOutputsWithRadix(Subcircuit subcircuit)
    {
        if (_probeBySubcircuit.TryGetValue(subcircuit, out var probe))
            return GetPortsWithRadix(probe.OutputPorts, probe.OutputNets);

        var outputPorts = subcircuit.Outputs;
        var chars = new char[outputPorts.Count];

        for (int i = 0; i < outputPorts.Count; i++)
        {
            var port = outputPorts[i];
            var value = GetPortByte(port);
            chars[i] = port.ToChar(value);
        }

        return new string(chars);
    }

    private void SetInputNet(Net net, byte value, string portTitle)
    {
        if (value > 2)
            throw new ArgumentOutOfRangeException(nameof(value), $"Invalid input value {value} for port {portTitle} in {Subcircuit.Title}");

        _deltaKernel.Set(net, value);
    }

    private void SetInputsWithRadix(string values)
    {
        var inputPorts = _rootProbe.InputPorts;
        if (values.Length != inputPorts.Length)
            throw new ArgumentException($"Input length mismatch: expected {inputPorts.Length}, got {values.Length}");

        var inputNets = _rootProbe.InputNets;
        for (int i = 0; i < values.Length; i++)
        {
            var port = inputPorts[i];
            var value = port.ToByte(values[i]);
            SetInputNet(inputNets[i], value, port.Title);
        }
    }

    private static string GetPortsWithRadix(Port[] ports, Net[] nets)
    {
        var chars = new char[ports.Length];

        for (var i = 0; i < ports.Length; i++)
            chars[i] = ports[i].ToChar(nets[i].Value);

        return new string(chars);
    }
}
