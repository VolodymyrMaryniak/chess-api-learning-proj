using ChessAPI.Models;

namespace ChessAPI.Errors;

public static class ErrorsFactory
{
    public static Error UserAlreadyExistsError => new("UserNameUniquenessError", "A player with that username already exists");
}
