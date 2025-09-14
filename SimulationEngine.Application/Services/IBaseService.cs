using SimulationEngine.Domain.Models;

namespace SimulationEngine.Application.Services;

public interface IBaseService<TEntity> where TEntity : BaseEntity
{
    Task<TEntity> CreateOrGetAsync(TEntity entity);
    Task<List<TEntity>> GetAllAsync();
    Task<TEntity> GetByIdAsync(int id);
    Task Populate();
}