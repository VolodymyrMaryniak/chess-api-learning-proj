using ChessAPI.Data.EntityModels;

namespace ChessAPI.Data.Repositories;

public interface IPlayerRepository : IRepository<Player>
{
    Task<Player?> FindByUserNameAsync(string userName);
}
