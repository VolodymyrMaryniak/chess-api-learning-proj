using ChessAPI.Data.DocumentModels;
using ChessAPI.Models.Dto.Player;
using ChessAPI.Models.Dto.Player.Requests;
using Riok.Mapperly.Abstractions;

namespace ChessAPI.Mapping;

[Mapper]
public static partial class PlayerMapper
{
    public static partial Player ToEntity(CreatePlayerRequestDto createPlayerRequestDto);
    public static partial PlayerDto ToDto(Player player);
}
