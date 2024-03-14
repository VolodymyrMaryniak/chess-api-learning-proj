using ChessAPI.Models.Dto.Game.Requests;
using ChessAPI.Models.Dto.Game.Responses;

namespace ChessAPI.Services;

public interface IGameService
{
    Task<GameResponseDto?> GetGameByIdAsync(string id);
    Task<GameResponseDto> CreateGameAsync(CreateGameRequestDto createGameRequestDto);
}
