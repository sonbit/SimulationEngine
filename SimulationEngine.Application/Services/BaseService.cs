using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Repositories;

namespace SimulationEngine.Application.Services;

public class BaseService<TEntity>(IBaseRepository<TEntity> repository) : IBaseService<TEntity> where TEntity : BaseEntity
{
    public virtual async Task<TEntity> CreateAsync(TEntity entity) => await repository.CreateAsync(entity);

    public async Task<IEnumerable<TEntity>> GetAllAsync() => await repository.GetAllAsync();

    public async Task<TEntity> GetByIdAsync(int id) => await repository.GetByIdAsync(id);

    public virtual Task Populate() => throw new NotImplementedException();
}
