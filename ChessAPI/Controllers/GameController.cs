using ChessAPI.Errors;
using ChessAPI.Extensions;
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
        return gameResponseDto switch
        {
            null => NotFound(),
            _ => Ok(gameResponseDto)
        };
    }

    [HttpPost]
    [ProducesResponseType(typeof(GameResponseDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateGame([FromBody] CreateGameRequestDto createGameRequestDto)
    {
        var gameResponseDto = await gameService.CreateGameAsync(createGameRequestDto);
        return CreatedAtAction(nameof(GetGame), new { id = gameResponseDto.Game.Id }, gameResponseDto);
    }
    
    [HttpPost("{id}/start")]
    [ProducesResponseType(typeof(GameResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> StartGame([FromRoute] string id)
    {
        var result = await gameService.StartGameAsync(id);
        return result switch
        {
            { IsSuccess: true } => Ok(result.Value),
            { Error.ErrorCode: ErrorCodes.GameNotFoundError } => NotFound(),
            _ => this.BadRequestWithErrorDetails(result.Error)
        };
    }
    
    [HttpPost("{id}/result")]
    [ProducesResponseType(typeof(GameResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> EndGame([FromRoute] string id, [FromBody] EndGameRequestDto endGameRequestDto)
    {
        var result = await gameService.EndGameAsync(id, endGameRequestDto);
        return result switch
        {
            { IsSuccess: true } => Ok(result.Value),
            { Error.ErrorCode: ErrorCodes.GameNotFoundError } => NotFound(),
            _ => this.BadRequestWithErrorDetails(result.Error)
        };
    }
}
