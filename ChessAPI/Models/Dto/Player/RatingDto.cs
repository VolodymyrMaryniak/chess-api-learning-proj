namespace ChessAPI.Models.Dto.Player;

public class RatingDto
{
    public required string Type { get; set; }
    public required int Value { get; set; }
    public required bool IsConfirmed { get; set; }
}
