using SimulationEngine.Domain.Models.Enums;
using SimulationEngine.Domain.Models.Metadata;
using SimulationEngine.Domain.Models.Metadata.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimulationEngine.Domain.Models;

public class Port : Terminal
{
    public Port() { }

    public Port(Radix radix) => PortMetadata = new PortMetadata(radix);

    public Port(Port port) : this(port.PortMetadata.Radix)
    {
        Title = port.Title;
        Direction = port.Direction;
        Ordinal = port.Ordinal;
    }

    public PortDirection Direction { get; set; }
    [NotMapped] public string Name => $"{Direction}_{Ordinal}";
    public int Ordinal { get; set; }

    public PortMetadata PortMetadata { get; set; } = new PortMetadata();
    public int PortMetadataId { get; set; }
    public SubCircuit SubCircuit { get; set; }
    public int SubCircuitId { get; set; }
}