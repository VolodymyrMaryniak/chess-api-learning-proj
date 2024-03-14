namespace ChessAPI.Models.Configurations;

public class ChessDatabaseSettings
{
    public const string SettingsKey = "ChessDatabase";

    public string ConnectionString { get; set; }
    public string DatabaseName { get; set; }
}
