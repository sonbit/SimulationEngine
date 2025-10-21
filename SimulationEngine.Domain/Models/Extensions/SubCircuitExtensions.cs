using SimulationEngine.Domain.Models.Enums;
using SimulationEngine.Domain.Models.Metadata.Enums;

namespace SimulationEngine.Domain.Models.Extensions;

public static class SubcircuitExtensions
{
    public static void AddBinaryInput(this Subcircuit subcircuit, string title = null) =>
        subcircuit.AddInput(title, Radix.Binary);

    public static void AddBinaryOutput(this Subcircuit subcircuit, string title = null) =>
        subcircuit.AddOutput(title, Radix.Binary);

    public static void AddBinaryInputs(this Subcircuit subcircuit, int count)
    {
        for (var i = 0; i < count; i++)
            subcircuit.AddBinaryInput();
    }

    public static void AddBinaryInputs(this Subcircuit subcircuit, params string[] titles)
    {
        foreach (var title in titles)
            subcircuit.AddBinaryInput(title);
    }

    public static LogicGate AddBinaryLogicGate(this Subcircuit subcircuit, string heptaIndex) =>
        subcircuit.AddLogicGate(heptaIndex, Radix.Binary);

    public static void AddBinaryOutputs(this Subcircuit subcircuit, int count)
    {
        for (var i = 0; i < count; i++)
            subcircuit.AddBinaryOutput();
    }

    public static void AddBinaryOutputs(this Subcircuit subcircuit, params string[] titles)
    {
        foreach (var title in titles)
            subcircuit.AddBinaryOutput(title);
    }

    public static void AddInput(this Subcircuit subcircuit, string title = null) =>
        subcircuit.AddPort(title, PortDirection.Input);

    public static void AddInput(this Subcircuit subcircuit, Radix radix) =>
        subcircuit.AddPort(null, PortDirection.Input, radix);

    public static void AddInput(this Subcircuit subcircuit, string title, Radix radix) =>
        subcircuit.AddPort(title, PortDirection.Input, radix);

    public static void AddInputs(this Subcircuit subcircuit, int count)
    {
        for (var i = 0; i < count; i++)
            subcircuit.AddInput();
    }

    public static void AddInputs(this Subcircuit subcircuit, params string[] titles)
    {
        foreach (var title in titles)
            subcircuit.AddInput(title);
    }

    public static void AddInputs(this Subcircuit subcircuit, params Radix[] radixes)
    {
        foreach (var radix in radixes)
            subcircuit.AddInput(radix);
    }

    public static void AddInputs(this Subcircuit subcircuit, params (string title, Radix radix)[] inputs)
    {
        foreach (var (title, radix) in inputs)
            subcircuit.AddInput(title, radix);
    }

    public static LogicGate AddLogicGate(this Subcircuit subcircuit, string heptaIndex, Radix radix = Radix.TernaryBalanced)
    {
        var logicGate = new LogicGate(heptaIndex, radix) { Subcircuit = subcircuit };
        subcircuit.LogicGates.Add(logicGate);
        return logicGate;
    }

    public static void AddPort(this Subcircuit subcircuit, string title, PortDirection direction, Radix radix = Radix.TernaryBalanced)
    {
        var port = new Port(radix)
        {
            Title = title,
            Direction = direction,
            Ordinal = direction == PortDirection.Input
                    ? subcircuit.Inputs.Count
                    : subcircuit.Outputs.Count,
            Subcircuit = subcircuit
        };

        subcircuit.Ports.Add(port);
    }

    public static T AddSubcircuit<T>(this Subcircuit parent, T subcircuit) where T : Subcircuit
    {
        parent.Subcircuits.Add(subcircuit);
        return subcircuit;
    }
       
    public static void AddOutput(this Subcircuit subcircuit, string title = null) =>
        subcircuit.AddPort(title, PortDirection.Output);

    public static void AddOutput(this Subcircuit subcircuit, Radix radix) =>
        subcircuit.AddPort(null, PortDirection.Output, radix);

    public static void AddOutput(this Subcircuit subcircuit, string title, Radix radix) =>
        subcircuit.AddPort(title, PortDirection.Output, radix);

    public static void AddOutputs(this Subcircuit subcircuit, int count)
    {
        for (var i = 0; i < count; i++)
            subcircuit.AddOutput();
    }

    public static void AddOutputs(this Subcircuit subcircuit, params string[] titles)
    {
        foreach (var title in titles)
            subcircuit.AddOutput(title);
    }

    public static void AddOutputs(this Subcircuit subcircuit, params Radix[] radixes)
    {
        foreach (var radix in radixes)
            subcircuit.AddOutput(radix);
    }

    public static void AddOutputs(this Subcircuit subcircuit, params (string title, Radix radix)[] inputs)
    {
        foreach (var (title, radix) in inputs)
            subcircuit.AddOutput(title, radix);
    }

    public static void AddWire(this Subcircuit subcircuit, Terminal startTerminal, Terminal endTerminal) =>
        subcircuit.Wires.Add(new Wire { StartTerminal = startTerminal, EndTerminal = endTerminal, Subcircuit = subcircuit });

    public static void AddWires(this Subcircuit subcircuit, params (Terminal startTerminal, Terminal endTerminal)[] wires)
    {
        foreach (var (startTerminal, endTerminal) in wires)
            subcircuit.AddWire(startTerminal, endTerminal);
    }
}