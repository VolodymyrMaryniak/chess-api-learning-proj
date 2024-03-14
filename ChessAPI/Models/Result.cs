using System.Diagnostics.CodeAnalysis;

namespace ChessAPI.Models;

public class Result<T>
{
    private Result() { }

    public static Result<T> Success(T value) => new()
    {
        IsSuccess = true,
        Value = value
    };

    public static Result<T> Failed(Error error) => new()
    {
        IsSuccess = false,
        Error = error
    };

    public T? Value { get; private init; }
    public Error? Error { get; private init; }

    [MemberNotNullWhen(true, nameof(Value))]
    [MemberNotNullWhen(false, nameof(Error))]
    public bool IsSuccess { get; private init; }
}
