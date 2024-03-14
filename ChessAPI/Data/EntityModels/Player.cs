using ChessAPI.Data.EntityModels.Shared;
using MongoDB.Bson.Serialization.Attributes;

namespace ChessAPI.Data.EntityModels;

public class Player : Entity
{
    [BsonElement("user_name")] public required string UserName { get; set; }

    [BsonElement("first_name")] public required string FirstName { get; set; }

    [BsonElement("last_name")] public required string LastName { get; set; }

    [BsonElement("ratings")] public List<Rating> Ratings { get; set; } = [];

    public class Rating
    {
        [BsonElement("type")] public required string Type { get; set; }

        [BsonElement("value")] public required int Value { get; set; }

        [BsonElement("is_confirmed")] public required bool IsConfirmed { get; set; }
    }
}
