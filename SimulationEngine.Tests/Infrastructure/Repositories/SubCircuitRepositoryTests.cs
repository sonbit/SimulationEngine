using Microsoft.EntityFrameworkCore;
using SimulationEngine.Designs.Subcircuits.Memory;
using SimulationEngine.Designs.Subcircuits.Multiplexers;
using SimulationEngine.Domain.Compilers;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Models.Enums;
using SimulationEngine.Domain.Models.Placements;
using SimulationEngine.Infrastructure.DataModel;
using SimulationEngine.Infrastructure.Repositories;

namespace SimulationEngine.Tests.Infrastructure.Repositories;

public sealed class SubcircuitRepositoryTests
{
    private static SubcircuitRepository CreateRepository(SimulationEngineDbContext dbContext) => new(dbContext, new TruthTableRepository(dbContext));

    [Fact]
    public async Task CreateOrGet_IncludingChildrenOfChildren()
    {
        using var db = new SqliteInMemoryDb();
        await using var dbContext = db.NewContext();
        var repository = CreateRepository(dbContext);

        var ram3 = new RAM3();
        var newDbRam3 = await repository.CreateOrGetAsync(ram3);

        Assert.NotNull(newDbRam3);

        var dbRam3 = await repository.GetByIdAsync(newDbRam3.Id);

        Assert.NotNull(dbRam3);
        Assert.Equal(3, dbRam3.Subcircuits.Count);

        var ram3Closure = SubcircuitCompiler.Compile(dbRam3);
        Assert.Equal(newDbRam3.Hash, ram3Closure.Placed.Template.Hash);
    }

    [Fact]
    public async Task CreateOrGet_PersistingDeduplication()
    {
        using var db = new SqliteInMemoryDb();
        await using var dbContext = db.NewContext();
        var repository = CreateRepository(dbContext);

        var muxX = new MUX();
        var muxY = new MUX();

        var dbMuxX = await repository.CreateOrGetAsync(muxX);
        var dbMuxY = await repository.CreateOrGetAsync(muxY);

        Assert.Equal(dbMuxX.Hash, dbMuxY.Hash);

        var equalHashCount = await dbContext.Subcircuits.AsNoTracking().CountAsync(subcircuit => subcircuit.Hash == dbMuxX.Hash);
        Assert.Equal(1, equalHashCount);

        var totalSubcircuits = await dbContext.Subcircuits.AsNoTracking().CountAsync();
        Assert.True(totalSubcircuits >= 2);
    }

    [Fact]
    public async Task CreateOrGet_PlacementPortsEmpty()
    {
        using var db = new SqliteInMemoryDb();
        await using var dbContext = db.NewContext();
        var repository = CreateRepository(dbContext);

        var mux = new MUX();

        var newDbMux = await repository.CreateOrGetAsync(mux);
        var dbMux = await repository.GetByIdAsync(newDbMux.Id);

        Assert.NotNull(dbMux);
        Assert.Equal(4, dbMux.Subcircuits.Count);

        var anyPlacementPortWire = dbMux.Wires.Any(wire => wire.StartTerminal is PortPlacement || wire.EndTerminal is PortPlacement);

        var anyPlacementPortChildWire = dbMux.Subcircuits
            .SelectMany(subcircuit => subcircuit.Wires)
            .Any(wire => wire.StartTerminal is PortPlacement || wire.EndTerminal is PortPlacement);

        Assert.False(anyPlacementPortWire || anyPlacementPortChildWire);

        var muxClosure = SubcircuitCompiler.Compile(dbMux);
        Assert.Equal(newDbMux.Hash, muxClosure.Placed.Template.Hash);
    }

    [Fact]
    public async Task CreateOrGet_UsesExistingTruthTables()
    {
        using var db = new SqliteInMemoryDb();
        await using var dbContext = db.NewContext();

        var truthTableRepository = new TruthTableRepository(dbContext);
        var repository = CreateRepository(dbContext);

        var heptaIndex = "ZD0PPPPPP";
        await truthTableRepository.CreateOrGetAsync(new TruthTable { HeptaIndex = heptaIndex });

        var mux = new MUX();
        var savedMux = await repository.CreateOrGetAsync(mux);

        Assert.NotNull(savedMux);

        var truthTables = await dbContext.TruthTables.AsNoTracking().ToListAsync();
        Assert.Single(truthTables.Where(truthTable => truthTable.HeptaIndex == heptaIndex));

        var logicGates = await dbContext.LogicGates.Include(logicGate => logicGate.TruthTable).AsNoTracking().ToListAsync();
        Assert.All(
            logicGates.Where(logicGate => logicGate.TruthTable.HeptaIndex == heptaIndex),
            logicGate => Assert.Equal(heptaIndex, logicGate.TruthTable.HeptaIndex));
    }

    [Fact]
    public async Task CreateOrGet_WiredAsExpected()
    {
        using var db = new SqliteInMemoryDb();
        await using var dbContext = db.NewContext();
        var repository = CreateRepository(dbContext);

        var _3mux = new _3MUX();
        var newDb3Mux = await repository.CreateOrGetAsync(_3mux);

        var db3Mux = await repository.GetByIdAsync(newDb3Mux.Id);

        Assert.NotNull(db3Mux);

        var pinQWiredToOut0 = db3Mux.Wires.Any(wire =>
            wire.StartTerminal is Pin pinQ && pinQ.Role == PinRole.Q &&
            wire.EndTerminal is Port portOut && portOut.Direction == PortDirection.Output && portOut.Ordinal == 0);

        Assert.True(pinQWiredToOut0);
    }
}