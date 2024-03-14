namespace ChessAPI.Models.Dto.Game.Requests;

public class CreateGameRequestDto
{
    public required string WhitePlayerId { get; set; }
    public required string BlackPlayerId { get; set; }
}
