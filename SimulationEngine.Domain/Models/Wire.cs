namespace SimulationEngine.Domain.Models
{
    public class Wire
    {
        public int Id { get; set; }
        
        public Port StartPort { get; set; }
        public int StartPortId { get; set; }
        public Port EndPort { get; set; }
        public int EndPortId { get; set; }
        public SubCircuit SubCircuit { get; set; }
        public int? SubCircuitId { get; set; }
    }
}