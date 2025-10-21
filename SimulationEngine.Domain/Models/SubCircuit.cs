using SimulationEngine.Domain.Models.Extensions;
using SimulationEngine.Domain.Models.Metadata;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace SimulationEngine.Domain.Models;

public class Subcircuit : BaseTitleEntity
{
    public Subcircuit() => Title ??= GetType().Name.Trim('_');

    public string Hash { get; set; }

    public List<LogicGate> LogicGates { get; set; } = [];
    public List<Port> Ports { get; set; } = [];
    public SubcircuitMetadata Metadata { get; set; }
    public int? SubcircuitMetadataId { get; set; }
    public List<Wire> Wires { get; set; } = [];

    [NotMapped] public List<Port> Inputs => [.. Ports.Where(p => p.IsInput()).OrderBy(p => p.Ordinal)];
    [NotMapped] public List<Port> OrderedPorts => [.. Inputs, .. Outputs];
    [NotMapped] public List<Port> Outputs => [.. Ports.Where(p => p.IsOutput()).OrderBy(p => p.Ordinal)];
    [NotMapped] public List<Subcircuit> Subcircuits { get; set; } = [];

    public virtual string GetTestString() => string.Empty;
}