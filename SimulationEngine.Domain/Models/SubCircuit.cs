using System.Collections.Generic;

namespace SimulationEngine.Domain.Models
{
    public class SubCircuit
    {
        public int Id { get; set; }
        public string Title { get; set; }
        
        public SubCircuit Parent { get; set; }
        public int? ParentId { get; set; }
        public List<SubCircuit> Children { get; set; }
        public List<Input> Inputs { get; set; }
        public List<LogicGate> LogicGates { get; set; }
        public List<Output> Outputs { get; set; }
        public List<Wire> Wires { get; set; }
    }
}