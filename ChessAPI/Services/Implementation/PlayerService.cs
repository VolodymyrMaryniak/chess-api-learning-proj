﻿using ChessAPI.Data.Repositories;
using ChessAPI.Errors;
using ChessAPI.Extensions;
using ChessAPI.Mapping;
using ChessAPI.Models;
using ChessAPI.Models.Dto.Player.Requests;
using ChessAPI.Models.Dto.Player.Responses;

namespace ChessAPI.Services.Implementation;

public class PlayerService(IPlayerRepository repository) : IPlayerService
{
    public async Task<PlayerResponseDto?> GetPlayerByIdAsync(string id)
    {
        var player = await repository.FindAsync(id);
        if (player is null)
            return null;

        var playerDto = PlayerMapper.ToDto(player);
        return new PlayerResponseDto { Player = playerDto };
    }

    public async Task<PlayerResponseDto?> GetPlayerByUserNameAsync(string userName)
    {
        var player = await repository.FindByUserNameAsync(userName);
        if (player is null)
            return null;

        var playerDto = PlayerMapper.ToDto(player);
        return new PlayerResponseDto { Player = playerDto };
    }

    public async Task<Result<PlayerResponseDto>> CreatePlayerAsync(CreatePlayerRequestDto createPlayerRequestDto)
    {
        var existingPlayerWithUserName = await repository.FindByUserNameAsync(createPlayerRequestDto.UserName);
        if (existingPlayerWithUserName is not null)
            return ErrorsFactory.UserNameUniquenessError.ToErrorResult<PlayerResponseDto>();

        var document = PlayerMapper.ToDocument(createPlayerRequestDto);

        var createdDocument = await repository.CreateAsync(document);

        var playerDto = PlayerMapper.ToDto(createdDocument);
        var responseDto = new PlayerResponseDto { Player = playerDto };
        return responseDto.ToSuccessResult();
    }
}
