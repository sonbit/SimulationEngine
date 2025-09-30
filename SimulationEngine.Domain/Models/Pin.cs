using SimulationEngine.Domain.Models.Enums;
using SimulationEngine.Domain.Models.Metadata;
using SimulationEngine.Domain.Models.Metadata.Enums;

namespace SimulationEngine.Domain.Models;

public class Pin : Terminal
{
    public Pin() => Title ??= Role.ToString();

    public Pin(Radix radix) : this() => Metadata = new PinMetadata(radix);

    public PinRole Role { get; set; }

    public LogicGate LogicGate { get; set; }
    public int LogicGateId { get; set; }
    public PinMetadata Metadata { get; set; } = new PinMetadata();
    public int PinMetadataId { get; set; }
}