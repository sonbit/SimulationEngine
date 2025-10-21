namespace SimulationEngine.Domain.Models.Placements;

public class PortPlacement : Terminal
{
    public PortPlacement() { }

    public PortPlacement(bool isInput, int indexWithinChild, string title, SubcircuitPlacement subcircuitPlacement)
    {
        IsInput = isInput;
        IndexWithinChild = indexWithinChild;
        Title = title;
        SubcircuitPlacement = subcircuitPlacement;
    }

    public bool IsInput { get; init; }
    public int IndexWithinChild { get; init; }

    public int SubcircuitPlacementId { get; init; }
    public SubcircuitPlacement SubcircuitPlacement { get; init; }
}