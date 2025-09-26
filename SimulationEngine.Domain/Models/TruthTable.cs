using SimulationEngine.Domain.Converters;
using SimulationEngine.Domain.Models.Metadata;
using SimulationEngine.Domain.Models.Metadata.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimulationEngine.Domain.Models;

public class TruthTable : BaseTitleEntity
{
    public TruthTable () { }

    public TruthTable (Radix radix) => Metadata = new TruthTableMetadata(radix);

    public string HeptaIndex { get; set; }

    public List<LogicGate> LogicGates { get; set; } = [];
    public TruthTableMetadata Metadata { get; set; } = new TruthTableMetadata();
    public int PortMetadataId { get; set; }

    [NotMapped] public byte[] Definition => HeptaIndexConverter.GetByteArray(HeptaIndex, Metadata.Radix);
}