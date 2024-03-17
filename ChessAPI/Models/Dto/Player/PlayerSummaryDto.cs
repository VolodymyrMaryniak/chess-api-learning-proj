namespace ChessAPI.Models.Dto.Player;

public class PlayerSummaryDto
{
    public required string Id { get; set; }
    public required string UserName { get; set; }
    public required List<RatingDto> Ratings { get; set; }
}
