using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Repositories;
using SimulationEngine.Infrastructure.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimulationEngine.Infrastructure.Repositories;

public class TruthTableRepository(SimulationEngineDbContext dbContext) : ITruthTableRepository
{
    private readonly SimulationEngineDbContext _dbContext = dbContext;

    public async Task<TruthTable> CreateOrGetAsync(TruthTable truthTable)
    {
        var local = _dbContext.TruthTables.Local.FirstOrDefault(tt => tt.HeptaIndex == truthTable.HeptaIndex);
        if (local is not null) 
            return local;

        var existing = await GetTruthTableQuery().FirstOrDefaultAsync(tt => tt.HeptaIndex == truthTable.HeptaIndex);
        if (existing is not null)
            return existing;

        await _dbContext.TruthTables.AddAsync(truthTable);

        try
        {
            await _dbContext.SaveChangesAsync();
            return truthTable;
        }
        catch (DbUpdateException ex) when (ex.InnerException is SqliteException se && se.SqliteErrorCode == 19)
        {
            return _dbContext.TruthTables.Local.FirstOrDefault(tt => tt.HeptaIndex == truthTable.HeptaIndex) ?? 
                await GetTruthTableQuery().FirstAsync(tt => tt.HeptaIndex == truthTable.HeptaIndex);
        }
    }

    public async Task<List<TruthTable>> CreateOrGetRangeAsync(List<TruthTable> truthTables)
    {
        var heptaIndexes = GetHeptaIndexes(truthTables);

        var existingTruthTables = await GetTruthTableQuery()
            .Where(tt => heptaIndexes.Contains(tt.HeptaIndex))
            .ToDictionaryAsync(tt => tt.HeptaIndex, StringComparer.Ordinal);

        var dbTruthTables = new List<TruthTable>(truthTables.Count);

        foreach (var truthTable in truthTables)
        {
            if (existingTruthTables.TryGetValue(truthTable.HeptaIndex, out var existing))
            {
                dbTruthTables.Add(existing);
                continue;
            }

            var newTruthTable = await CreateOrGetAsync(truthTable);
            dbTruthTables.Add(newTruthTable);
            existingTruthTables[truthTable.HeptaIndex] = newTruthTable;
        }

        return dbTruthTables;
    }

    public async Task<List<TruthTable>> GetAllAsync() =>
        await GetTruthTableQuery().ToListAsync();

    public async Task<TruthTable> GetByHeptaIndexAsync(string heptaIndex) =>
        await GetTruthTableQuery().FirstOrDefaultAsync(truthTable => truthTable.HeptaIndex == heptaIndex);

    public async Task<TruthTable> GetByIdAsync(int id) =>
        await GetTruthTableQuery().FirstOrDefaultAsync(truthTable => truthTable.Id == id);

    private static HashSet<string> GetHeptaIndexes(List<TruthTable> truthTables) =>
        truthTables.Select(truthTable => truthTable.HeptaIndex).ToHashSet(StringComparer.Ordinal);

    private IIncludableQueryable<TruthTable, List<LogicGate>> GetTruthTableQuery()
    {
        return _dbContext.TruthTables
            .AsNoTracking()
            .Include(truthTable => truthTable.LogicGates);
    }
}