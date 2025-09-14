using SimulationEngine.Domain.Extensions;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Enums;
using System.Collections.Generic;
using System.Linq;

namespace SimulationEngine.Domain.Comparers;

public sealed class LogicGateOrderComparer : IComparer<LogicGate>
{
    public static readonly LogicGateOrderComparer Instance = new();

    public int Compare(LogicGate logicGateX, LogicGate logicGateY)
    {
        if (ReferenceEquals(logicGateX, logicGateY)) 
            return 0;

        if (logicGateX is null) 
            return -1; 

        if (logicGateY is null) 
            return 1;

        string hiX = logicGateX.TruthTable?.HeptaIndex ?? "";
        string hiY = logicGateY.TruthTable?.HeptaIndex ?? "";

        int cmp = string.CompareOrdinal(hiX, hiY);
        if (cmp != 0) 
            return cmp;

        int maskX = logicGateX.GetPinMask(); 
        int maskY = logicGateY.GetPinMask();

        cmp = maskX.CompareTo(maskY);
        if (cmp != 0) 
            return cmp;

        int arX = logicGateX.Pins?.Count ?? 0;
        int arY = logicGateY.Pins?.Count ?? 0;

        cmp = arX.CompareTo(arY);
        if (cmp != 0) 
            return cmp;

        return 0;
    }

    private static int PinMask(LogicGate g)
    {
        int m = 0;

        foreach (var p in g.Pins ?? Enumerable.Empty<Pin>())
        {
            m |= p.Role switch
            {
                PinRole.A => 1,
                PinRole.B => 2,
                PinRole.C => 4,
                PinRole.D => 8,
                PinRole.Q => 16,
                _ => 0
            };
        }

        return m;
    }
}