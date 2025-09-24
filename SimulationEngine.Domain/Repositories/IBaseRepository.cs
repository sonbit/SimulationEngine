using SimulationEngine.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimulationEngine.Domain.Repositories;

public interface IBaseRepository<TEntity> where TEntity : BaseEntity
{
    Task<TEntity> CreateOrGetAsync(TEntity entity);
    Task<List<TEntity>> GetAllAsync();
    Task<TEntity> GetByIdAsync(int id);
}