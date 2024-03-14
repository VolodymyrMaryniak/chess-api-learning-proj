using ChessAPI.Data.DocumentModels.Shared;

namespace ChessAPI.Data.Repositories;

public interface IRepository<TEntity> 
    where TEntity : Document
{
    Task<TEntity?> FindAsync(string id);
    Task<TEntity> CreateAsync(TEntity entity);
}
