using ChessAPI.Data.EntityModels.Shared;

namespace ChessAPI.Data.Repositories;

public interface IRepository<TEntity> 
    where TEntity : Entity
{
    Task<TEntity?> FindAsync(string id);
    Task<TEntity> CreateAsync(TEntity entity);
}
