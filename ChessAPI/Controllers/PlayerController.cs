using ChessAPI.Models.Dto.Player.Requests;
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
        if (result == null)
            return NotFound();
        
        return Ok(result);
    }
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(PlayerResponseDto))]
    public async Task<IActionResult> CreatePlayer([FromBody] CreatePlayerRequestDto createPlayerRequestDto)
    {
        var result = await playerService.CreatePlayerAsync(createPlayerRequestDto);
        return CreatedAtAction(nameof(GetPlayer), new { id = result.Player.Id }, result);
    }
}
