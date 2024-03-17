using ChessAPI.Models.Dto.Player;
using ChessAPI.Models.Enums;

namespace ChessAPI.Models.Dto.Game;

public class GameDetailsDto
{
    public required string Id { get; set; }
    
    public required PlayerSummaryDto WhitePlayer { get; set; }
    public required PlayerSummaryDto BlackPlayer { get; set; }
    
    public DateTime? StartedAt { get; set; }
    public DateTime? EndedAt { get; set; }
    
    public GameResult? Result { get; set; }
}
