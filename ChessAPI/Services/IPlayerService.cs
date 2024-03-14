using ChessAPI.Models;
using ChessAPI.Models.Dto.Player.Requests;
using ChessAPI.Models.Dto.Player.Responses;

namespace ChessAPI.Services;

public interface IPlayerService
{
    Task<PlayerResponseDto?> GetPlayerByIdAsync(string id);
    Task<PlayerResponseDto?> GetPlayerByUserNameAsync(string userName);
    Task<Result<PlayerResponseDto>> CreatePlayerAsync(CreatePlayerRequestDto createPlayerRequestDto);
}
