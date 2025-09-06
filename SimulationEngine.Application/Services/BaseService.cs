using SimulationEngine.Application.Services.Interfaces;
using SimulationEngine.Domain.Models;
using SimulationEngine.Domain.Repositories;

namespace SimulationEngine.Application.Services;

public class BaseService<TEntity>(IBaseRepository<TEntity> repository) : IBaseService<TEntity> where TEntity : BaseEntity
{
    public Task<List<TEntity>> GetAllAsync() => repository.GetAllAsync();

    public Task<TEntity> GetByIdAsync(int id) => repository.GetByIdAsync(id);
}
