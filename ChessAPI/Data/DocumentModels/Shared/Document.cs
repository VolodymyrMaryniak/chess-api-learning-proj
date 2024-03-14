﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ChessAPI.Data.DocumentModels.Shared;

public abstract class Document
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
}
