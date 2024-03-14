using ChessAPI.Data.EntityModels;
using ChessAPI.Data.Repositories;
using ChessAPI.Mapping;
using ChessAPI.Models.Dto.Player.Requests;
using ChessAPI.Models.Dto.Player.Responses;

namespace ChessAPI.Services.Implementation;

public class PlayerService(IRepository<Player> repository) : IPlayerService
{
    public async Task<PlayerResponseDto?> GetPlayerByIdAsync(string id)
    {
        var player = await repository.FindAsync(id);
        if (player == null)
            return null;

        var playerDto = PlayerMapper.ToDto(player);
        return new PlayerResponseDto { Player = playerDto };
    }
    
    public async Task<PlayerResponseDto> CreatePlayerAsync(CreatePlayerRequestDto createPlayerRequestDto)
    {
        var entity = PlayerMapper.ToEntity(createPlayerRequestDto);
        var createdEntity = await repository.CreateAsync(entity);
        
        var playerDto = PlayerMapper.ToDto(createdEntity);
        return new PlayerResponseDto { Player = playerDto };
    }
}
