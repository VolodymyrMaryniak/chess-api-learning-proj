using ChessAPI.Data.DocumentModels;
using ChessAPI.Data.Schema;
using MongoDB.Driver;

namespace ChessAPI.Data.Repositories.Implementation;

public class GameRepository(IMongoDatabase database) 
    : Repository<Game>(database, CollectionNames.Games), IGameRepository
{
    public async Task<GameWithPlayersProjection?> GetGameDetailsAsync(string gameId)
    {
        var playersCollection = Database.GetCollection<Player>(CollectionNames.Players);

        var game = await Collection.Aggregate()
            .Lookup<Game, Player, GameWithPlayersProjection>(playersCollection, g => g.WhitePlayerId, p => p.Id, g => g.WhitePlayer)
            .Unwind(g => g.WhitePlayer, new AggregateUnwindOptions<GameWithPlayersProjection> { PreserveNullAndEmptyArrays = true })
            .Lookup<GameWithPlayersProjection, Player, GameWithPlayersProjection>(playersCollection, g => g.BlackPlayerId, p => p.Id, g => g.BlackPlayer)
            .Unwind(g => g.BlackPlayer, new AggregateUnwindOptions<GameWithPlayersProjection> { PreserveNullAndEmptyArrays = true })
            .Match(g => g.Id == gameId)
            .FirstOrDefaultAsync();

        return game;
    }
}
