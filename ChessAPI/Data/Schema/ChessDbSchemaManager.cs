using ChessAPI.Data.DocumentModels;
using MongoDB.Driver;

namespace ChessAPI.Data.Schema;

public class ChessDbSchemaManager(IMongoDatabase database)
{
    public async Task EnsureSchemaAppliedAsync()
    {
        var collection = database.GetCollection<Player>(CollectionNames.Players);

        var indexOptions = new CreateIndexOptions { Unique = true };
        var indexKeys = Builders<Player>.IndexKeys.Ascending("user_name");
        var indexModel = new CreateIndexModel<Player>(indexKeys, indexOptions);

        await collection.Indexes.CreateOneAsync(indexModel);
    }
}
