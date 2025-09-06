using SimulationEngine.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimulationEngine.Domain.Repositories;

public interface IBaseRepository<TEntity> where TEntity : BaseEntity
{
    Task<TEntity> CreateAsync(TEntity entity);
    bool DeleteAsync(int id);
    Task<List<TEntity>> GetAllAsync();
    Task<TEntity> GetByIdAsync(int id);
    Task<bool> UpdateAsync(int id, TEntity source);
}