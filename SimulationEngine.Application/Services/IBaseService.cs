using SimulationEngine.Domain.Models;

namespace SimulationEngine.Application.Services;

public interface IBaseService<TEntity> where TEntity : BaseEntity
{
    Task<TEntity> CreateAsync(TEntity entity);
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task<TEntity> GetByIdAsync(int id);
    Task Populate();
}