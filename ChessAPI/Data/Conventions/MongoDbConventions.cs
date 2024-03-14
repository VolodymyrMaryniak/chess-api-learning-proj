using MongoDB.Bson;
using MongoDB.Bson.Serialization.Conventions;

namespace ChessAPI.Data.Conventions;

public static class MongoDbConventions
{
    public static void RegisterMongoDbConventions()
    {
        ConventionRegistry.Register("EnumStringConvention", new ConventionPack
        {
            new EnumRepresentationConvention(BsonType.String)
        }, _ => true);
    }
}
