using SimulationEngine.Domain.Models;

namespace SimulationEngine.Application.Services.Interfaces;

public interface IBaseService<TEntity> where TEntity : BaseEntity
{
    Task<List<TEntity>> GetAllAsync();
    Task<TEntity> GetByIdAsync(int id);
}