using SimulationEngine.Domain.Models.Enums;
using SimulationEngine.Domain.Models.Metadata;
using SimulationEngine.Domain.Models.Metadata.Enums;

namespace SimulationEngine.Domain.Models;

public class Port : Terminal
{
    public Port() => Title ??= $"{Direction}_{Ordinal}";

    public Port(Radix radix) : this() => Metadata = new PortMetadata(radix);

    public Port(Port port) : this(port.Metadata.Radix)
    {
        Title = port.Title;
        Direction = port.Direction;
        Ordinal = port.Ordinal;
    }

    public PortDirection Direction { get; set; }
    public int Ordinal { get; set; }

    public PortMetadata Metadata { get; set; } = new PortMetadata();
    public int PortMetadataId { get; set; }
    public Subcircuit Subcircuit { get; set; }
    public int SubcircuitId { get; set; }
}