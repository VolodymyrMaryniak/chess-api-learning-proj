using ChessAPI.Data.EntityModels;
using ChessAPI.Data.EntityModels.Shared;
using ChessAPI.Data.Repositories;
using ChessAPI.Data.Repositories.Implementation;
using ChessAPI.Models.Configurations;
using ChessAPI.Services;
using ChessAPI.Services.Implementation;
using MongoDB.Driver;

namespace ChessAPI.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddDatabaseAndRepositories(this IServiceCollection services, IConfiguration configuration)
    {
        var mongoDbSettings = configuration
            .GetRequiredSection(ChessDatabaseSettings.SettingsKey)
            .Get<ChessDatabaseSettings>() ?? throw new InvalidOperationException($"{nameof(ChessDatabaseSettings)} not found");

        services.AddSingleton<IMongoClient>(_ => new MongoClient(mongoDbSettings.ConnectionString));
        services.AddSingleton<IMongoDatabase>(sp => sp.GetRequiredService<IMongoClient>().GetDatabase(mongoDbSettings.DatabaseName));

        // Register repositories
        services.AddRepository<Player>("players");
    }

    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IPlayerService, PlayerService>();
    }

    private static void AddRepository<TEntity>(this IServiceCollection services, string collectionName)
        where TEntity : Entity
    {
        services.AddScoped<IRepository<TEntity>>(sp =>
        {
            var database = sp.GetRequiredService<IMongoDatabase>();
            return new GenericRepository<TEntity>(database, collectionName);
        });
    }
}
