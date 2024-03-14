using ChessAPI.Data.DocumentModels.Shared;
using ChessAPI.Models.Enums;
using MongoDB.Bson.Serialization.Attributes;

namespace ChessAPI.Data.DocumentModels;

public class Game : Document
{
    [BsonElement("white_player_id")] public required string WhitePlayerId { get; set; }
    [BsonElement("black_player_id")] public required string BlackPlayerId { get; set; }

    [BsonElement("started_at")] public DateTime? StartedAt { get; set; }
    [BsonElement("ended_at")] public DateTime? EndedAt { get; set; }
    
    [BsonElement("result")] public GameResult? Result { get; set; }
}
