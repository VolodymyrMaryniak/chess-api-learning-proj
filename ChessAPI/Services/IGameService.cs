using ChessAPI.Models;
using ChessAPI.Models.Dto.Game.Requests;
using ChessAPI.Models.Dto.Game.Responses;

namespace ChessAPI.Services;

public interface IGameService
{
    Task<GameResponseDto?> GetGameByIdAsync(string id);
    Task<DetailedGameResponseDto?> GetGameDetailsByIdAsync(string id);
    Task<GameResponseDto> CreateGameAsync(CreateGameRequestDto createGameRequestDto);
    Task<Result<GameResponseDto>> StartGameAsync(string id);
    Task<Result<GameResponseDto>> EndGameAsync(string id, EndGameRequestDto endGameRequestDto);
}
