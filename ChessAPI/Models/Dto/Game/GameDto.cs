using ChessAPI.Models.Enums;

namespace ChessAPI.Models.Dto.Game;

public class GameDto
{
    public required string Id { get; set; }
    
    public required string WhitePlayerId { get; set; }
    public required string BlackPlayerId { get; set; }
    
    public DateTime? StartedAt { get; set; }
    public DateTime? EndedAt { get; set; }
    
    public GameResult? Result { get; set; }
}
