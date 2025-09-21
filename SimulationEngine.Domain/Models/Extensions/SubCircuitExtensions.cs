using SimulationEngine.Domain.Models.Enums;
using SimulationEngine.Domain.Models.Metadata.Enums;
using System.Runtime.CompilerServices;

namespace SimulationEngine.Domain.Models.Extensions;

public static class SubCircuitExtensions
{
    public static void AddBinaryInput(this SubCircuit subCircuit, string title = null) =>
        subCircuit.AddInput(title, Radix.Binary);

    public static void AddBinaryOutput(this SubCircuit subCircuit, string title = null) =>
        subCircuit.AddOutput(title, Radix.Binary);

    public static void AddBinaryInputs(this SubCircuit subCircuit, int count)
    {
        for (var i = 0; i < count; i++)
            subCircuit.AddBinaryInput();
    }

    public static void AddBinaryInputs(this SubCircuit subCircuit, params string[] titles)
    {
        foreach (var title in titles)
            subCircuit.AddBinaryInput(title);
    }

    public static void AddBinaryOutputs(this SubCircuit subCircuit, int count)
    {
        for (var i = 0; i < count; i++)
            subCircuit.AddBinaryOutput();
    }

    public static void AddBinaryOutputs(this SubCircuit subCircuit, params string[] titles)
    {
        foreach (var title in titles)
            subCircuit.AddBinaryOutput(title);
    }

    public static void AddInput(this SubCircuit subCircuit, string title = null) =>
        subCircuit.AddPort(title, PortDirection.Input);

    public static void AddInput(this SubCircuit subCircuit, Radix radix) =>
        subCircuit.AddPort(null, PortDirection.Input, radix);

    public static void AddInput(this SubCircuit subCircuit, string title, Radix radix) =>
        subCircuit.AddPort(title, PortDirection.Input, radix);

    public static void AddInputs(this SubCircuit subCircuit, int count)
    {
        for (var i = 0; i < count; i++)
            subCircuit.AddInput();
    }

    public static void AddInputs(this SubCircuit subCircuit, params string[] titles)
    {
        foreach (var title in titles)
            subCircuit.AddInput(title);
    }

    public static void AddInputs(this SubCircuit subCircuit, params Radix[] radixes)
    {
        foreach (var radix in radixes)
            subCircuit.AddInput(radix);
    }

    public static void AddInputs(this SubCircuit subCircuit, params (string title, Radix radix)[] inputs)
    {
        foreach (var (title, radix) in inputs)
            subCircuit.AddInput(title, radix);
    }

    public static LogicGate AddLogicGate(this SubCircuit subCircuit, string heptaIndex)
    {
        var logicGate = new LogicGate(heptaIndex) { SubCircuit = subCircuit };
        subCircuit.LogicGates.Add(logicGate);
        return logicGate;
    }

    public static void AddPort(this SubCircuit subCircuit, string title, PortDirection direction, Radix radix = Radix.TernaryBalanced)
    {
        var port = new Port(radix)
        {
            Title = title,
            Direction = direction,
            Ordinal = direction == PortDirection.Input
                    ? subCircuit.Inputs.Count
                    : subCircuit.Outputs.Count,
            SubCircuit = subCircuit
        };

        subCircuit.Ports.Add(port);
    }

    public static T AddSubCircuit<T>(this SubCircuit parent, T subCircuit) where T : SubCircuit
    {
        parent.SubCircuits.Add(subCircuit);
        return subCircuit;
    }
       
    public static void AddOutput(this SubCircuit subCircuit, string title = null) =>
        subCircuit.AddPort(title, PortDirection.Output);

    public static void AddOutput(this SubCircuit subCircuit, Radix radix) =>
        subCircuit.AddPort(null, PortDirection.Output, radix);

    public static void AddOutput(this SubCircuit subCircuit, string title, Radix radix) =>
        subCircuit.AddPort(title, PortDirection.Output, radix);

    public static void AddOutputs(this SubCircuit subCircuit, int count)
    {
        for (var i = 0; i < count; i++)
            subCircuit.AddOutput();
    }

    public static void AddOutputs(this SubCircuit subCircuit, params string[] titles)
    {
        foreach (var title in titles)
            subCircuit.AddOutput(title);
    }

    public static void AddOutputs(this SubCircuit subCircuit, params Radix[] radixes)
    {
        foreach (var radix in radixes)
            subCircuit.AddOutput(radix);
    }

    public static void AddOutputs(this SubCircuit subCircuit, params (string title, Radix radix)[] inputs)
    {
        foreach (var (title, radix) in inputs)
            subCircuit.AddOutput(title, radix);
    }

    public static void AddWire(this SubCircuit subCircuit, Terminal startTerminal, Terminal endTerminal) =>
        subCircuit.Wires.Add(new Wire { StartTerminal = startTerminal, EndTerminal = endTerminal, SubCircuit = subCircuit });

    public static void AddWires(this SubCircuit subCircuit, params (Terminal startTerminal, Terminal endTerminal)[] wires)
    {
        foreach (var (startTerminal, endTerminal) in wires)
            subCircuit.AddWire(startTerminal, endTerminal);
    }
}