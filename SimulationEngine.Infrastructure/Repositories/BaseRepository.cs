using Microsoft.EntityFrameworkCore;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Repositories;
using SimulationEngine.Infrastructure.DataModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimulationEngine.Infrastructure.Repositories;

public class BaseRepository<TEntity>(SimulationEngineDbContext dbContext) : IBaseRepository<TEntity> where TEntity : BaseEntity, new()
{
    private readonly DbSet<TEntity> _dbSet = dbContext.Set<TEntity>();

    public async Task<TEntity> CreateAsync(TEntity entity)
    {
        await _dbSet.AddAsync(entity);
        return entity;
    }

    public async Task<IEnumerable<TEntity>> CreateRangeAsync(IEnumerable<TEntity> entities)
    {
        await _dbSet.AddRangeAsync(entities);
        return entities;
    }

    public bool DeleteAsync(int id)
    {
        var stub = new TEntity { Id = id };
        dbContext.Attach(stub);
        dbContext.Remove(stub);
        return true;
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync() => await _dbSet.AsNoTracking().ToListAsync();

    public Task<TEntity> GetByIdAsync(int id) => _dbSet.AsNoTracking().FirstOrDefaultAsync(entity => entity.Id == id);

    public async Task<bool> UpdateAsync(int id, TEntity entity)
    {
        var existingEntity = await GetByIdAsync(id);
        if (existingEntity is null) 
            return false;

        dbContext.Entry(existingEntity).CurrentValues.SetValues(entity);

        return true;
    }
}