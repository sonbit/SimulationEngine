using SimulationEngine.Domain.Comparers;
using SimulationEngine.Domain.Extensions;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace SimulationEngine.Domain.Models;

public class SubCircuit : BaseEntity
{
    public SubCircuit() => Title ??= GetType().Name.Trim('_');

    public string Title { get; set; }
    public string Hash { get; set; }

    public List<LogicGate> LogicGates { get; set; } = [];
    public List<Port> Ports { get; set; } = [];
    public List<Wire> Wires { get; set; } = [];

    [NotMapped] public List<Port> Inputs => [.. Ports?.Where(p => p.Role.IsInput()).OrderBy(p => p, PortOrderComparer.Instance)];
    [NotMapped] public List<SubCircuit> SubCircuits { get; set; } = [];
    [NotMapped] public List<Port> Outputs => [.. Ports?.Where(p => p.Role.IsOutput()).OrderBy(p => p, PortOrderComparer.Instance)];
}