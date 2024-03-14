using ChessAPI.Data.DocumentModels;
using ChessAPI.Data.Repositories;
using ChessAPI.Mapping;
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
        var document = GameMapper.ToDocument(createGameRequestDto);
        var createdDocument = await repository.CreateAsync(document);

        var gameDto = GameMapper.ToDto(createdDocument);
        return new GameResponseDto { Game = gameDto };
    }
}
