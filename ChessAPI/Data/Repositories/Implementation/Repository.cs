using ChessAPI.Data.DocumentModels.Shared;
using MongoDB.Driver;

namespace ChessAPI.Data.Repositories.Implementation;

public class Repository<TEntity>(IMongoDatabase database, string collectionName) : IRepository<TEntity>
    where TEntity : Document
{
    protected IMongoDatabase Database => database;
    protected IMongoCollection<TEntity> Collection => Database.GetCollection<TEntity>(collectionName);

    public async Task<TEntity?> FindAsync(string id)
    {
        return await Collection.Find(entity => entity.Id == id).FirstOrDefaultAsync();
    }
    
    public async Task<TEntity> CreateAsync(TEntity entity)
    {
        await Collection.InsertOneAsync(entity);
        return entity;
    }
    
    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        await Collection.ReplaceOneAsync(e => e.Id == entity.Id, entity);
        return entity;
    }
}
