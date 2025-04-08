namespace SimulationEngine.Domain.Models
{
    public class LogicGate
    {
        public int Id { get; set; }
        
        public Port PortA { get; set; }
        public int? PortAId { get; set; }
        public Port PortB { get; set; }
        public int? PortBId { get; set; }
        public Port PortC { get; set; }
        public int? PortCId { get; set; }
        public Port PortD { get; set; }
        public int? PortDId { get; set; }
        public Port PortQ { get; set; }
        public int? PortQId { get; set; }
        public TruthTable TruthTable { get; set; }
        public int TruthTableId { get; set; }
        public SubCircuit SubCircuit { get; set; }
        public int? SubCircuitId { get; set; }
    }
}