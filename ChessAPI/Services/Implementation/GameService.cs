using ChessAPI.Data.Repositories;
using ChessAPI.Errors;
using ChessAPI.Extensions;
using ChessAPI.Mapping;
using ChessAPI.Models;
using ChessAPI.Models.Dto.Game.Requests;
using ChessAPI.Models.Dto.Game.Responses;

namespace ChessAPI.Services.Implementation;

public class GameService(IGameRepository gameRepository) : IGameService
{
    public async Task<GameResponseDto?> GetGameByIdAsync(string id)
    {
        var game = await gameRepository.FindAsync(id);
        if (game is null)
            return null;

        var gameDto = GameMapper.ToDto(game);
        return new GameResponseDto { Game = gameDto };
    }
    
    public async Task<DetailedGameResponseDto?> GetGameDetailsByIdAsync(string id)
    {
        var gameDetails = await gameRepository.GetGameDetailsAsync(id);
        if (gameDetails is null)
            return null;
        
        var gameDetailsDto = GameMapper.ToDetailsDto(gameDetails);
        return new DetailedGameResponseDto { Game = gameDetailsDto };
    }

    public async Task<GameResponseDto> CreateGameAsync(CreateGameRequestDto createGameRequestDto)
    {
        var game = GameMapper.ToDocument(createGameRequestDto);
        var createdDocument = await gameRepository.CreateAsync(game);

        var gameDto = GameMapper.ToDto(createdDocument);
        return new GameResponseDto { Game = gameDto };
    }
    
    public async Task<Result<GameResponseDto>> StartGameAsync(string id)
    {
        var game = await gameRepository.FindAsync(id);
        if (game is null)
            return ErrorsFactory.GameNotFoundError.ToErrorResult<GameResponseDto>();

        if (game.StartedAt is not null)
            return ErrorsFactory.GameAlreadyStartedError.ToErrorResult<GameResponseDto>();
        
        game.StartedAt = DateTime.UtcNow;
        game = await gameRepository.UpdateAsync(game);
        
        var gameResponseDto = new GameResponseDto { Game = GameMapper.ToDto(game) };
        return gameResponseDto.ToSuccessResult();
    }
    
    public async Task<Result<GameResponseDto>> EndGameAsync(string id, EndGameRequestDto endGameRequestDto)
    {
        var game = await gameRepository.FindAsync(id);
        if (game is null)
            return ErrorsFactory.GameNotFoundError.ToErrorResult<GameResponseDto>();

        if (game.StartedAt is null)
            return ErrorsFactory.GameNotStartedError.ToErrorResult<GameResponseDto>();
        
        if (game.EndedAt is not null)
            return ErrorsFactory.GameAlreadyEndedError.ToErrorResult<GameResponseDto>();
        
        game.EndedAt = DateTime.UtcNow;
        game.Result = endGameRequestDto.Result;
        game = await gameRepository.UpdateAsync(game);
        
        var gameResponseDto = new GameResponseDto { Game = GameMapper.ToDto(game) };
        return gameResponseDto.ToSuccessResult();
    }
}
