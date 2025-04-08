using System.Collections.Generic;

namespace SimulationEngine.Domain.Models
{
    public class TruthTable
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string HeptaIndex { get; set; }
        public byte[] Definition { get; set; }
        
        public List<LogicGate> LogicGates { get; set; }
    }
}