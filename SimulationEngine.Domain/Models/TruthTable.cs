using SimulationEngine.Domain.Utils;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimulationEngine.Domain.Models;

public class TruthTable : BaseEntity
{
    public string HeptaIndex { get; set; }
    public string Title { get; set; }

    public List<LogicGate> LogicGates { get; set; } = [];

    [NotMapped] public byte[] Definition => HeptaIndexConverter.GetByteArray(HeptaIndex);
}