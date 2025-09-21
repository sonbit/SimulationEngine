using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Extensions;
using System.Collections.Generic;

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

        var logicGateXHeptaIndex = logicGateX.TruthTable?.HeptaIndex ?? "";
        var logicGateYHeptaIndex = logicGateY.TruthTable?.HeptaIndex ?? "";

        int cmp = string.CompareOrdinal(logicGateXHeptaIndex, logicGateYHeptaIndex);
        if (cmp != 0) 
            return cmp;

        int logicGateXPinMask = logicGateX.GetPinMask(); 
        int logicGateYPinMask = logicGateY.GetPinMask();

        cmp = logicGateXPinMask.CompareTo(logicGateYPinMask);
        if (cmp != 0) 
            return cmp;

        int logicGateXPinCount = logicGateX.Pins?.Count ?? 0;
        int logicGateYPinCount = logicGateY.Pins?.Count ?? 0;

        cmp = logicGateXPinCount.CompareTo(logicGateYPinCount);
        if (cmp != 0) 
            return cmp;

        return 0;
    }
}