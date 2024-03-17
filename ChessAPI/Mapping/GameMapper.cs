using ChessAPI.Data.DocumentModels;
using ChessAPI.Models.Dto.Game;
using ChessAPI.Models.Dto.Game.Requests;
using Riok.Mapperly.Abstractions;

namespace ChessAPI.Mapping;

[Mapper]
public static partial class GameMapper
{
    public static partial Game ToDocument(CreateGameRequestDto createGameRequestDto);
    public static partial GameDto ToDto(Game game);
    public static partial GameDetailsDto ToDetailsDto(GameWithPlayersProjection game);
}
