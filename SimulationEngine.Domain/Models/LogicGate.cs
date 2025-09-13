using SimulationEngine.Domain.Extensions;
using SimulationEngine.Domain.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace SimulationEngine.Domain.Models;

public class LogicGate : BaseEntity
{
    public LogicGate() { }

    public LogicGate(string heptaIndex)
    {
        this.AddPins(heptaIndex);

        TruthTable = new TruthTable { HeptaIndex = heptaIndex };
    }

    public string Hash { get; set; }

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