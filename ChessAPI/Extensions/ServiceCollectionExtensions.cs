using ChessAPI.Constants;
using ChessAPI.Data.DocumentModels;
using ChessAPI.Data.DocumentModels.Shared;
using ChessAPI.Data.Repositories;
using ChessAPI.Data.Repositories.Implementation;
using ChessAPI.Data.Schema;
using ChessAPI.Services;
using ChessAPI.Services.Implementation;
using MongoDB.Driver;

namespace ChessAPI.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddDatabaseAndRepositories(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IMongoClient>(_ =>
        {
            string connectionString = configuration.GetRequiredConfiguration<string>(SettingKeys.DefaultConnectionSettingKey);
            return new MongoClient(connectionString);
        });

        services.AddSingleton<IMongoDatabase>(sp =>
        {
            string databaseName = configuration.GetRequiredConfiguration<string>(SettingKeys.ChessDatabaseNameSettingKey);
            return sp.GetRequiredService<IMongoClient>().GetDatabase(databaseName);
        });

        // Register schema manager
        services.AddScoped<ChessDbSchemaManager>();

        // Register repositories
        services.AddScoped<IPlayerRepository, PlayerRepository>();
        services.AddRepository<Player>(CollectionNames.Players);
    }

    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IPlayerService, PlayerService>();
    }

    private static void AddRepository<TEntity>(this IServiceCollection services, string collectionName)
        where TEntity : Document
    {
        services.AddScoped<IRepository<TEntity>>(sp =>
        {
            var database = sp.GetRequiredService<IMongoDatabase>();
            return new GenericRepository<TEntity>(database, collectionName);
        });
    }
}
