using ChessAPI.Models.Enums;

namespace ChessAPI.Models.Dto.Game.Requests;

public class EndGameRequestDto
{
    public required GameResult Result { get; set; }
}
