using SimulationEngine.Domain.Comparers;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Enums;

namespace SimulationEngine.Tests.Domain.Comparers;

public sealed class PortOrderComparerTests
{
    [Fact]
    public void Compare_InputsBeforeOutputs()
    {
        var input = CreatePort(PortRole.In0);
        var output = CreatePort(PortRole.Out0);

        Assert.True(PortOrderComparer.Instance.Compare(input, output) < 0);
        Assert.True(PortOrderComparer.Instance.Compare(output, input) > 0);
    }

    [Fact]
    public void Compare_NullOrdering()
    {
        var port = CreatePort(PortRole.In0);

        Assert.True(PortOrderComparer.Instance.Compare(null, port) < 0);
        Assert.True(PortOrderComparer.Instance.Compare(port, null) > 0);
        Assert.Equal(0, PortOrderComparer.Instance.Compare(null, null));
    }

    [Fact]
    public void Compare_SameReference()
    {
        var port = CreatePort(PortRole.In0);
        Assert.Equal(0, PortOrderComparer.Instance.Compare(port, port));
    }

    [Fact]
    public void Compare_SameRole()
    {
        var portX = CreatePort(PortRole.In0);
        var portY = CreatePort(PortRole.In0);

        Assert.Equal(0, PortOrderComparer.Instance.Compare(portX, portY));
    }

    [Fact]
    public void Compare_SortedByRole()
    {
        var in0 = CreatePort(PortRole.In0);
        var in1 = CreatePort(PortRole.In1);
        var out0 = CreatePort(PortRole.Out0);
        var out1 = CreatePort(PortRole.Out1);

        Assert.True(PortOrderComparer.Instance.Compare(in0, in1) < 0);
        Assert.True(PortOrderComparer.Instance.Compare(out0, out1) < 0);
    }

    [Fact]
    public void Compare_SortedOrder()
    {
        var list = new List<Port>
        {
            CreatePort(PortRole.Out1),
            CreatePort(PortRole.In1),
            CreatePort(PortRole.In0),
            CreatePort(PortRole.Out0),
            CreatePort(PortRole.In2),
        };

        list.Sort(PortOrderComparer.Instance);

        Assert.True(list.Take(3).All(p => p.Role.ToString().StartsWith("In", StringComparison.Ordinal)));
        Assert.Equal(PortRole.In0, list[0].Role);
        Assert.Equal(PortRole.In1, list[1].Role);
        Assert.Equal(PortRole.In2, list[2].Role);
        Assert.Equal(PortRole.Out0, list[3].Role);
        Assert.Equal(PortRole.Out1, list[4].Role);
    }

    private static Port CreatePort(PortRole role) => new() { Role = role };
}