using SimulationEngine.Domain.Comparers;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Enums;

namespace SimulationEngine.Tests.Domain;

public sealed class LogicGateOrderComparerTests
{
    [Fact]
    public void Compare_AllEqual()
    {
        var heptaIndex = "20K";

        var logicGateX = CreateLogicGate(heptaIndex, PinRole.A, PinRole.B, PinRole.Q);
        var logicGateY = CreateLogicGate(heptaIndex, PinRole.A, PinRole.B, PinRole.Q);

        Assert.Equal(0, LogicGateOrderComparer.Instance.Compare(logicGateX, logicGateY));
    }

    [Fact]
    public void Compare_EmptyHeptaIndexFirst()
    {
        var logicGateX = CreateLogicGate(null, PinRole.A, PinRole.Q);
        var logicGateY = CreateLogicGate("5", PinRole.A, PinRole.Q);

        Assert.True(LogicGateOrderComparer.Instance.Compare(logicGateX, logicGateY) < 0);
        Assert.True(LogicGateOrderComparer.Instance.Compare(logicGateY, logicGateX) > 0);
    }

    [Fact]
    public void Compare_HeptaIndexOrdering()
    {
        var logicGateX = CreateLogicGate("2", PinRole.A, PinRole.Q);
        var logicGateY = CreateLogicGate("5", PinRole.A, PinRole.Q);

        Assert.True(LogicGateOrderComparer.Instance.Compare(logicGateX, logicGateY) < 0);
        Assert.True(LogicGateOrderComparer.Instance.Compare(logicGateY, logicGateX) > 0);
    }

    [Fact]
    public void Compare_NullOrdering()
    {
        var logicGate = CreateLogicGate("5", PinRole.A, PinRole.Q);

        Assert.True(LogicGateOrderComparer.Instance.Compare(null, logicGate) < 0);
        Assert.True(LogicGateOrderComparer.Instance.Compare(logicGate, null) > 0);
        Assert.Equal(0, LogicGateOrderComparer.Instance.Compare(null, null));
    }

    [Fact]
    public void Compare_PinCountOrdering()
    {
        var heptaIndex = "20K";

        var logicGateX = CreateLogicGate(heptaIndex, PinRole.A, PinRole.Q);
        var logicGateY = CreateLogicGate(heptaIndex, PinRole.A, PinRole.B, PinRole.Q);

        Assert.True(LogicGateOrderComparer.Instance.Compare(logicGateX, logicGateY) < 0);
        Assert.True(LogicGateOrderComparer.Instance.Compare(logicGateY, logicGateX) > 0);
    }

    [Fact]
    public void Compare_PinMaskOrdering()
    {
        var heptaIndex = "20K";

        var logicGateX = CreateLogicGate(heptaIndex, PinRole.A, PinRole.Q);
        var logicGateY = CreateLogicGate(heptaIndex, PinRole.B, PinRole.Q);

        Assert.True(LogicGateOrderComparer.Instance.Compare(logicGateX, logicGateY) < 0);
        Assert.True(LogicGateOrderComparer.Instance.Compare(logicGateY, logicGateX) > 0);
    }

    [Fact]
    public void Compare_SameReference_Equal()
    {
        var logicGate = CreateLogicGate("5", PinRole.A);
        Assert.Equal(0, LogicGateOrderComparer.Instance.Compare(logicGate, logicGate));
    }

    private static LogicGate CreateLogicGate(string? heptaIndex, params PinRole[] pinRoles)
    {
        return new LogicGate
        {
            TruthTable = heptaIndex is null ? null : new TruthTable { HeptaIndex = heptaIndex },
            Pins = pinRoles?.Select(role => new Pin { Role = role }).ToList()
        };
    }
}