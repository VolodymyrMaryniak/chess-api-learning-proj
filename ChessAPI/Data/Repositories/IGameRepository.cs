using ChessAPI.Data.DocumentModels;

namespace ChessAPI.Data.Repositories;

public interface IGameRepository : IRepository<Game>
{
    Task<GameWithPlayersProjection?> GetGameDetailsAsync(string gameId);
}
