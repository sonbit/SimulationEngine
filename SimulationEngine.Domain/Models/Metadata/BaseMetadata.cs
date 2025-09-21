namespace SimulationEngine.Domain.Models.Metadata;

public abstract class BaseMetadata : BaseEntity
{
    public float? PositionX { get; set; }
    public float? PositionY { get; set; }
}