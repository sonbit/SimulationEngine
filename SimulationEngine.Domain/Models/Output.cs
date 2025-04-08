using System.Collections.Generic;

namespace SimulationEngine.Domain.Models
{
    public class Output
    {
        public int Id { get; set; }
        
        public List<Port> Ports { get; set; }
        public SubCircuit SubCircuit { get; set; }
        public int? SubCircuitId { get; set; }
    }
}