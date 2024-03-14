using ChessAPI.Models.Dto.Game.Requests;
using ChessAPI.Models.Dto.Game.Responses;
using ChessAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ChessAPI.Controllers;

[Route("api/game")]
[ApiController]
public class GameController(IGameService gameService) : ControllerBase
{
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(GameResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetGame([FromRoute] string id)
    {
        var gameResponseDto = await gameService.GetGameByIdAsync(id);
        if (gameResponseDto is null)
            return NotFound();

        return Ok(gameResponseDto);
    }

    [HttpPost]
    [ProducesResponseType(typeof(GameResponseDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateGame([FromBody] CreateGameRequestDto createGameRequestDto)
    {
        var gameResponseDto = await gameService.CreateGameAsync(createGameRequestDto);
        return CreatedAtAction(nameof(GetGame), new { id = gameResponseDto.Game.Id }, gameResponseDto);
    }
}
