namespace ChessAPI.Models.Dto.Player;

public class PlayerDto
{
    public required string Id { get; set; }
    public required string UserName { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required List<RatingDto> Ratings { get; set; }
}
