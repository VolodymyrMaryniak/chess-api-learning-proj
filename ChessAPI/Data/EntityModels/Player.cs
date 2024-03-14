using ChessAPI.Data.EntityModels.Shared;

namespace ChessAPI.Data.EntityModels;

public class Player : Entity
{
    public required string UserName { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }

    public List<Rating> Ratings { get; set; } = [];

    public class Rating
    {
        public required string Type { get; set; }
        public required int Value { get; set; }
        public required bool IsConfirmed { get; set; }
    }
}
