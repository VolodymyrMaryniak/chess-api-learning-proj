using ChessAPI.Data.EntityModels.Shared;
using MongoDB.Driver;

namespace ChessAPI.Data.Repositories.Implementation;

public abstract class Repository<TEntity>(IMongoDatabase database) : IRepository<TEntity>
    where TEntity : Entity
{
    protected abstract string CollectionName { get; }
    protected IMongoCollection<TEntity> Collection => database.GetCollection<TEntity>(CollectionName);

    public async Task<TEntity?> FindAsync(string id)
    {
        // TODO: Check which one is better
        // return await Collection.Find(Builders<TEntity>.Filter.Eq("_id", id)).FirstOrDefaultAsync();

        return await Collection.Find(entity => entity.Id == id).FirstOrDefaultAsync();
    }
    
    public async Task<TEntity> CreateAsync(TEntity entity)
    {
        await database.GetCollection<TEntity>(CollectionName).InsertOneAsync(entity);
        return entity;
    }
}
