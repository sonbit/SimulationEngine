namespace SimulationEngine.Domain.Models
{
    public class Port
    {
        public int Id { get; set; }
        public string Title { get; set; }
        // public byte Value { get; set; } // Shouldn't be stored in DB
        
        public Input Input { get; set; }
        public int? InputId { get; set; }
        public Output Output { get; set; }
        public int? OutputId { get; set; }
    }
}