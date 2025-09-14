using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Enums;
using System.Collections.Generic;

namespace SimulationEngine.Domain.Comparers;

public class PortOrderComparer : IComparer<Port>
{
    public static readonly PortOrderComparer Instance = new();

    public int Compare(Port portX, Port portY)
    {
        if (ReferenceEquals(portX, portY)) 
            return 0;

        if (portX is null) 
            return -1; 

        if (portY is null)
            return 1;

        var inPrefix = nameof(PortRole.In0)[..2];
        bool portXIn = portX.Role.ToString().StartsWith(inPrefix);
        bool portYIn = portY.Role.ToString().StartsWith(inPrefix);
        if (portXIn != portYIn) 
            return portXIn ? -1 : 1;

        int cmp = ((int)portX.Role).CompareTo((int)portY.Role);
        if (cmp != 0) 
            return cmp;

        return string.CompareOrdinal(portX.Title ?? "", portY.Title ?? "");
    }
}