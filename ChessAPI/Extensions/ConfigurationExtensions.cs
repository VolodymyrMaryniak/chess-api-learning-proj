namespace ChessAPI.Extensions;

public static class ConfigurationExtensions
{
    public static T GetRequiredConfiguration<T>(this IConfiguration configuration, string key)
    {
        var value = configuration.GetValue<T>(key);
        if (value is null)
        {
            throw new InvalidOperationException($"The configuration value for '{key}' is required but was not found.");
        }

        return value;
    }
}
