using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Extensions;
using SimulationEngine.Simulator.Models;

namespace SimulationEngine.Simulator;

public sealed record SimulationSessionBuildOptions
{
    public bool Trace { get; init; }
    public IReadOnlyCollection<Subcircuit>? ProbeSubcircuits { get; init; }
    public IReadOnlyCollection<string>? ProbeSubcircuitTitles { get; init; }
}

internal sealed class SubcircuitPortProbe
{
    public required Port[] InputPorts { get; init; }
    public required Net[] InputNets { get; init; }
    public required Port[] OutputPorts { get; init; }
    public required Net[] OutputNets { get; init; }
}

public partial class SimulationSession
{
    public void AddProbeSubcircuit(Subcircuit subcircuit)
    {
        if (_probeBySubcircuit.ContainsKey(subcircuit))
            return;

        _probeBySubcircuit[subcircuit] = BuildProbe(subcircuit);
    }

    private void InitializePortProbes(SimulationSessionBuildOptions options)
    {
        _probeBySubcircuit[Subcircuit] = BuildProbe(Subcircuit);
        _rootProbe = _probeBySubcircuit[Subcircuit];

        if (options.ProbeSubcircuits != null)
        {
            foreach (var subcircuit in options.ProbeSubcircuits)
                _probeBySubcircuit[subcircuit] = BuildProbe(subcircuit);
        }

        if (options.ProbeSubcircuitTitles == null || options.ProbeSubcircuitTitles.Count == 0)
            return;

        var titleSet = new HashSet<string>(options.ProbeSubcircuitTitles, StringComparer.Ordinal);
        foreach (var subcircuit in EnumerateAllSubcircuitsRecursive(Subcircuit))
        {
            if (!titleSet.Contains(subcircuit.Title))
                continue;

            _probeBySubcircuit[subcircuit] = BuildProbe(subcircuit);
        }
    }

    private SubcircuitPortProbe BuildProbe(Subcircuit subcircuit)
    {
        var inputPorts = subcircuit.Ports
            .Where(p => p.IsInput())
            .OrderBy(p => p.Ordinal)
            .ToArray();

        var outputPorts = subcircuit.Ports
            .Where(p => p.IsOutput())
            .OrderBy(p => p.Ordinal)
            .ToArray();

        var inputNets = new Net[inputPorts.Length];
        for (var i = 0; i < inputPorts.Length; i++)
            inputNets[i] = _netOfTerminals[inputPorts[i]];

        var outputNets = new Net[outputPorts.Length];
        for (var i = 0; i < outputPorts.Length; i++)
            outputNets[i] = _netOfTerminals[outputPorts[i]];

        return new SubcircuitPortProbe
        {
            InputPorts = inputPorts,
            InputNets = inputNets,
            OutputPorts = outputPorts,
            OutputNets = outputNets
        };
    }

    private static IEnumerable<Subcircuit> EnumerateAllSubcircuitsRecursive(Subcircuit subcircuit)
    {
        yield return subcircuit;

        foreach (var child in subcircuit.Subcircuits ?? [])
        {
            foreach (var inner in EnumerateAllSubcircuitsRecursive(child))
                yield return inner;
        }
    }
}
