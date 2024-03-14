using ChessAPI.Data.DocumentModels;

namespace ChessAPI.Data.Repositories;

public interface IPlayerRepository : IRepository<Player>
{
    Task<Player?> FindByUserNameAsync(string userName);
}
