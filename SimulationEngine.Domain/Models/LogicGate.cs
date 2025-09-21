using SimulationEngine.Domain.Models.Enums;
using SimulationEngine.Domain.Models.Extensions;
using SimulationEngine.Domain.Models.Metadata;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace SimulationEngine.Domain.Models;

public class LogicGate : BaseEntity
{
    public LogicGate() { }

    public LogicGate(string heptaIndex)
    {
        this.AddPins(heptaIndex);

        TruthTable = new TruthTable { HeptaIndex = heptaIndex };
    }

    public LogicGate(LogicGate logicGate)
    {
        TruthTable = logicGate.TruthTable;
        Pins = [.. logicGate.Pins.Select(pin => new Pin { Role = pin.Role })];
    }

    public string Hash { get; set; }

    public LogicGateMetadata LogicGateMetadata { get; set; } = new LogicGateMetadata();
    public int LogicGateMetadataId { get; set; }
    public List<Pin> Pins { get; set; } = [];
    public SubCircuit SubCircuit { get; set; }
    public int SubCircuitId { get; set; }
    public TruthTable TruthTable { get; set; }
    public int TruthTableId { get; set; }

    [NotMapped] public Pin A => Pins.SingleOrDefault(pin => pin.Role == PinRole.A);
    [NotMapped] public Pin B => Pins.SingleOrDefault(pin => pin.Role == PinRole.B);
    [NotMapped] public Pin C => Pins.SingleOrDefault(pin => pin.Role == PinRole.C);
    [NotMapped] public Pin D => Pins.SingleOrDefault(pin => pin.Role == PinRole.D);
    [NotMapped] public Pin Q => Pins.SingleOrDefault(pin => pin.Role == PinRole.Q);
}