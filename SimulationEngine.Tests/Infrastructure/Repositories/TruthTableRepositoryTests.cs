using Microsoft.EntityFrameworkCore;
using SimulationEngine.Designs;
using SimulationEngine.Domain.Models;
using SimulationEngine.Infrastructure.Repositories;

namespace SimulationEngine.Tests.Infrastructure.Repositories;

public sealed class TruthTableRepositoryTests
{
    [Fact]
    public async Task CreateOrGet_CreateNew()
    {
        using var db = new SqliteInMemoryDb();
        await using var dbContext = db.NewContext();
        var repository = new TruthTableRepository(dbContext);

        var truthTable = await repository.CreateOrGetAsync(CreateTruthTable("B7P"));

        Assert.NotEqual(0, truthTable.Id);
        Assert.Equal("B7P", truthTable.HeptaIndex);
        Assert.Equal(1, await dbContext.TruthTables.CountAsync());
    }

    [Fact]
    public async Task CreateOrGet_ReturnExisting_DueToHeptaIndex()
    {
        using var db = new SqliteInMemoryDb();
        await using var dbContext = db.NewContext();
        var repository = new TruthTableRepository(dbContext);

        var truthTableX = await repository.CreateOrGetAsync(CreateTruthTable("7"));
        var truthTableY = await repository.CreateOrGetAsync(new TruthTable { HeptaIndex = "7", Title = "Some Title" });

        Assert.Equal(truthTableX.Id, truthTableY.Id);
        Assert.Equal(1, await dbContext.TruthTables.CountAsync());
    }

    [Fact]
    public async Task CreateOrGetRange_Deduplication_EnsureLowerDbCount()
    {
        using var db = new SqliteInMemoryDb();
        await using var dbContext = db.NewContext();
        var repository = new TruthTableRepository(dbContext);

        var truthTables = new[]
        {
            CreateTruthTable("7"),
            CreateTruthTable("B7P"),
            new TruthTable { HeptaIndex = "7", Title = "Some Title" },
        }.ToList();

        var result = await repository.CreateOrGetRangeAsync(truthTables);

        Assert.Equal(3, result.Count);
        Assert.Equal(2, await dbContext.TruthTables.CountAsync());
        Assert.Equal(result[0].Id, result[2].Id);
    }

    [Fact]
    public async Task GetAllByTitle()
    {
        using var db = new SqliteInMemoryDb();
        await using var dbContext = db.NewContext();
        var repo = new TruthTableRepository(dbContext);

        await repo.CreateOrGetAsync(new TruthTable { HeptaIndex = "RDC", Title = "MAX" });
        await repo.CreateOrGetAsync(new TruthTable { HeptaIndex = "RDC", Title = "MAX" });
        await repo.CreateOrGetAsync(new TruthTable { HeptaIndex = "ZRP", Title = "MAX" });
        await repo.CreateOrGetAsync(new TruthTable { HeptaIndex = "ZRP", Title = string.Empty });
        await repo.CreateOrGetAsync(new TruthTable { HeptaIndex = "K00", Title = "MIN" });

        var truthTables = await repo.GetAllByTitleAsync("MAX");
        Assert.Equal(2, truthTables.Count);
        Assert.All(truthTables, truthTable => Assert.Equal("MAX", truthTable.Title));
    }

    [Fact]
    public async Task GetByHeptaIndex()
    {
        using var db = new SqliteInMemoryDb();
        await using var dbContext = db.NewContext();
        var repo = new TruthTableRepository(dbContext);

        await repo.CreateOrGetAsync(CreateTruthTable("B7P7PBPB7"));

        var truthTable = await repo.GetByHeptaIndexAsync("B7P7PBPB7");
        Assert.NotNull(truthTable);
        Assert.Equal("B7P7PBPB7", truthTable.HeptaIndex);
    }

    private static TruthTable CreateTruthTable(string heptaIndex) => heptaIndex.Length switch
    {
        1 => new TruthTable { HeptaIndex = heptaIndex, Title = StandardCellLibrary.GetArity1()[heptaIndex] },
        3 => new TruthTable { HeptaIndex = heptaIndex, Title = StandardCellLibrary.GetArity2()[heptaIndex] },
        9 => new TruthTable { HeptaIndex = heptaIndex, Title = StandardCellLibrary.GetArity3()[heptaIndex] },
        _ => throw new ArgumentException("Invalid hepta index length", nameof(heptaIndex)),
    };
}