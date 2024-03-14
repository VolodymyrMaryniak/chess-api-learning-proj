using ChessAPI.Data.EntityModels;
using ChessAPI.Data.Schema;
using MongoDB.Driver;

namespace ChessAPI.Data.Repositories.Implementation;

public class PlayerRepository(IMongoDatabase database)
    : GenericRepository<Player>(database, CollectionNames.Players), IPlayerRepository
{
    public async Task<Player?> FindByUserNameAsync(string userName)
    {
        var filter = Builders<Player>.Filter.Eq(p => p.UserName, userName);
        return await Collection.Find(filter).FirstOrDefaultAsync();
    }
}
