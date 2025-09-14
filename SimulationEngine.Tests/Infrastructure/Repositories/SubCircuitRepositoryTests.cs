using Microsoft.EntityFrameworkCore;
using SimulationEngine.Domain.Hashers;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Enums;
using SimulationEngine.Infrastructure.DataModel;
using SimulationEngine.Infrastructure.Repositories;

namespace SimulationEngine.Tests.Infrastructure.Repositories;
public sealed class SubCircuitRepositoryTests
{
    private static SubCircuitRepository CreateRepository(SimulationEngineDbContext ctx) => new(ctx, new TruthTableRepository(ctx));

    [Fact]
    public async Task CreateOrGet_InsertsAndReconnectsWires()
    {
        using var db = new SqliteInMemoryDb();
        await using var dbContext = db.NewContext();
        var repository = CreateRepository(dbContext);

        var subCircuit = ModelBuilders.CreateSubCircuitWithChild("SubCircuit");
        var subCircuitDb = await repository.CreateOrGetAsync(subCircuit);

        Assert.NotEqual(0, subCircuitDb.Id);
        Assert.False(string.IsNullOrWhiteSpace(subCircuitDb.Hash));

        Assert.Equal(2, await dbContext.SubCircuits.CountAsync());

        var subCircuitDbReloaded = await dbContext.SubCircuits
            .Include(subCircuit => subCircuit.Wires).ThenInclude(wire => wire.StartTerminal)
            .Include(subCircuit => subCircuit.Wires).ThenInclude(wire => wire.EndTerminal)
            .Include(subCircuit => subCircuit.Ports)
            .Include(subCircuit => subCircuit.LogicGates).ThenInclude(logicGate => logicGate.Pins)
            .AsNoTracking()
            .SingleAsync(subCircuit => subCircuit.Id == subCircuitDb.Id);

        Assert.Equal(3, subCircuitDbReloaded.Wires.Count);

        var pinQWiredToPortOut0 = subCircuitDbReloaded.Wires.Any(wire =>
            wire.StartTerminal is Pin pin && pin.Role == PinRole.Q &&
            wire.EndTerminal is Port port && port.Role.ToString().StartsWith(nameof(PortRole.Out0)[..3]));

        Assert.True(pinQWiredToPortOut0);
    }

    [Fact]
    public async Task CreateOrGet_ReusesExisting()
    {
        using var db = new SqliteInMemoryDb();
        await using var dbContext = db.NewContext();
        var repository = CreateRepository(dbContext);

        var subCircuitX = ModelBuilders.CreateSubCircuitWithChild("SubCircuitX");
        var subCircuitY = ModelBuilders.CreateSubCircuitWithChild("SubCircuitY");

        var subCircuitDbX = await repository.CreateOrGetAsync(subCircuitX);
        var subCircuitDbY = await repository.CreateOrGetAsync(subCircuitY);

        Assert.Equal(subCircuitDbX.Hash, subCircuitDbY.Hash);
        Assert.Equal(subCircuitDbX.Id, subCircuitDbY.Id);
        Assert.Equal(2, await dbContext.SubCircuits.CountAsync());
    }

    [Fact]
    public async Task CreateOrGet_SavesChildrenOnce()
    {
        using var db = new SqliteInMemoryDb();
        await using var dbContext = db.NewContext();
        var repository = CreateRepository(dbContext);

        var subCircuitX = ModelBuilders.CreateSubCircuitWithChild("SubCircuitX");
        var subCircuitY = ModelBuilders.CreateSubCircuitWithChild("SubCircuitY");

        var subCircuitDbX = await repository.CreateOrGetAsync(subCircuitX);
        var subCircuitDbY = await repository.CreateOrGetAsync(subCircuitY);

        Assert.Equal(2, await dbContext.SubCircuits.CountAsync());

        var subCircuits = await dbContext.SubCircuits.AsNoTracking().ToListAsync();
        var subCircuitChildHash = SubCircuitHasher.ComputeAndAssignHash(ModelBuilders.CreateSubCircuit("Child"));
        Assert.Contains(subCircuits, subCircuit => subCircuit.Hash == subCircuitChildHash);
    }

    [Fact]
    public async Task CreateOrGet_UsesExistingTruthTables()
    {
        using var db = new SqliteInMemoryDb();
        await using var dbContext = db.NewContext();
        var truthTableRepository = new TruthTableRepository(dbContext);
        var repository = CreateRepository(dbContext);

        await truthTableRepository.CreateOrGetAsync(new TruthTable { HeptaIndex = "20K", Title = "SUM" });

        var subCircuit = ModelBuilders.CreateSubCircuitWithChild("SubCircuit");
        var subCircuitDb = await repository.CreateOrGetAsync(subCircuit);

        var truthTables = await dbContext.TruthTables.AsNoTracking().ToListAsync();
        Assert.Single(truthTables.Where(truthTable => truthTable.HeptaIndex == "20K"));

        var logicGates = await dbContext.LogicGates.Include(logicGate => logicGate.TruthTable).AsNoTracking().ToListAsync();
        Assert.All(logicGates, logicGate => Assert.Equal("20K", logicGate.TruthTable.HeptaIndex));
    }
}