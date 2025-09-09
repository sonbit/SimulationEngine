using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Repositories;

namespace SimulationEngine.Application.Services;

public class BaseService<TEntity>(IBaseRepository<TEntity> repository) : IBaseService<TEntity> where TEntity : BaseEntity
{
    public virtual Task<TEntity> CreateAsync(TEntity entity) => repository.CreateAsync(entity);

    public Task<List<TEntity>> GetAllAsync() => repository.GetAllAsync();

    public Task<TEntity> GetByIdAsync(int id) => repository.GetByIdAsync(id);

    public virtual Task Populate() => throw new NotImplementedException();
}
