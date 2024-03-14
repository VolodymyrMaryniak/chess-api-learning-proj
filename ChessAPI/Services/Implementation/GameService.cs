using ChessAPI.Data.DocumentModels;
using ChessAPI.Data.Repositories;
using ChessAPI.Errors;
using ChessAPI.Mapping;
using ChessAPI.Models;
using ChessAPI.Models.Dto.Game.Requests;
using ChessAPI.Models.Dto.Game.Responses;

namespace ChessAPI.Services.Implementation;

public class GameService(IRepository<Game> repository) : IGameService
{
    public async Task<GameResponseDto?> GetGameByIdAsync(string id)
    {
        var game = await repository.FindAsync(id);
        if (game is null)
            return null;

        var gameDto = GameMapper.ToDto(game);
        return new GameResponseDto { Game = gameDto };
    }
    
    public async Task<GameResponseDto> CreateGameAsync(CreateGameRequestDto createGameRequestDto)
    {
        var game = GameMapper.ToDocument(createGameRequestDto);
        var createdDocument = await repository.CreateAsync(game);

        var gameDto = GameMapper.ToDto(createdDocument);
        return new GameResponseDto { Game = gameDto };
    }
    
    public async Task<Result<GameResponseDto>> StartGameAsync(string id)
    {
        var game = await repository.FindAsync(id);
        if (game is null)
            return Result<GameResponseDto>.Failed(ErrorsFactory.GameNotFoundError);
        
        if (game.StartedAt is not null)
            return Result<GameResponseDto>.Failed(ErrorsFactory.GameAlreadyStartedError);
        
        game.StartedAt = DateTime.UtcNow;
        game = await repository.UpdateAsync(game);
        
        var gameDto = GameMapper.ToDto(game);
        return Result<GameResponseDto>.Success(new GameResponseDto { Game = gameDto });
    }
}
