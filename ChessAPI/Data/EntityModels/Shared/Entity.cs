using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ChessAPI.Data.EntityModels.Shared;

public abstract class Entity
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
}
