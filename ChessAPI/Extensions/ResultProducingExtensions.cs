using ChessAPI.Models;

namespace ChessAPI.Extensions;

public static class ResultProducingExtensions
{
    public static Result<T> ToErrorResult<T>(this Error error) => Result<T>.Failed(error);
    public static Result<T> ToSuccessResult<T>(this T value) => Result<T>.Success(value);
}
