using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace SimulationEngine.Domain.Models;

public class SubCircuit : BaseEntity
{
    public string Title { get; set; }

    public SubCircuit Parent { get; set; }
    public int? ParentId { get; set; }
    public List<SubCircuit> SubCircuits { get; set; } = [];
    public List<LogicGate> LogicGates { get; set; } = [];
    public List<Port> Ports { get; set; } = [];
    public List<Wire> Wires { get; set; } = [];

    [NotMapped] public List<Port> Inputs => [.. Ports?.Where(p => p.Role.ToString().StartsWith("In"))];
    [NotMapped] public List<Port> Outputs => [.. Ports?.Where(p => p.Role.ToString().StartsWith("Out"))];

    public SubCircuit() => Title ??= GetType().Name.Trim('_');
}