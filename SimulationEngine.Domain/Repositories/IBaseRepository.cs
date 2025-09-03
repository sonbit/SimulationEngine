using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimulationEngine.Domain.Repositories;

public interface IBaseRepository<TEntity>
{
    Task Create(TEntity entity);
    Task<ICollection<TEntity>> Read();
    Task<TEntity> Read(int id);
    Task Update(int id, TEntity entity);
    Task Delete(int id);
}