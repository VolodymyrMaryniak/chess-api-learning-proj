using ChessAPI.Data.EntityModels.Shared;
using MongoDB.Driver;

namespace ChessAPI.Data.Repositories.Implementation;

public class GenericRepository<TEntity>(IMongoDatabase database, string collectionName) : Repository<TEntity>(database) 
    where TEntity : Entity
{
    protected override string CollectionName => collectionName;
}
