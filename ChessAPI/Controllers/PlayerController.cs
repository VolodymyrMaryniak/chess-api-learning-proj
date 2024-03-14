﻿using ChessAPI.Models.Dto.Player.Requests;
using ChessAPI.Models.Dto.Player.Responses;
using ChessAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ChessAPI.Controllers;

[Route("api/player")]
[ApiController]
public class PlayerController(IPlayerService playerService) : ControllerBase
{
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PlayerResponseDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetPlayer([FromRoute] string id)
    {
        var result = await playerService.GetPlayerByIdAsync(id);
        if (result is null)
            return NotFound();

        return Ok(result);
    }
    
    [HttpGet("username/{userName}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PlayerResponseDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetPlayerByUserName([FromRoute] string userName)
    {
        var result = await playerService.GetPlayerByUserNameAsync(userName);
        if (result is null)
            return NotFound();

        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(PlayerResponseDto))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreatePlayer([FromBody] CreatePlayerRequestDto createPlayerRequestDto)
    {
        var result = await playerService.CreatePlayerAsync(createPlayerRequestDto);
        if (result.IsSuccess)
            return CreatedAtAction(nameof(GetPlayer), new { id = result.Value.Player.Id }, result.Value);

        ModelState.AddModelError(result.Error.ErrorCode, result.Error.Description);
        return BadRequest(ModelState);
    }
}
