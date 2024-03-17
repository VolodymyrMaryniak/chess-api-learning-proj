namespace ChessAPI.Errors;

public static class ErrorCodes
{
    public const string UserNameUniquenessError = "UserNameUniquenessError";
    public const string GameNotFoundError = "GameNotFoundError";
    public const string GameAlreadyStartedError = "GameAlreadyStartedError";
    public const string GameNotStartedError = "GameNotStartedError";
    public const string GameAlreadyEndedError = "GameAlreadyEndedError";
}
