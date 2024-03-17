namespace ChessAPI.Data.DocumentModels;

public class GameWithPlayersProjection : Game
{
    public required Player WhitePlayer { get; set; }

    public required Player BlackPlayer { get; set; }
}
