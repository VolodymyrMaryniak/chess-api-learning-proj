using ChessAPI.Models;

namespace ChessAPI.Errors;

public static class ErrorsFactory
{
    public static Error UserNameUniquenessError => new(ErrorCodes.UserNameUniquenessError, "A player with that username already exists");
    public static Error GameNotFoundError => new(ErrorCodes.GameNotFoundError, "A game with that id was not found");
    public static Error GameAlreadyStartedError => new(ErrorCodes.GameAlreadyStartedError, "The game has already started");
}
