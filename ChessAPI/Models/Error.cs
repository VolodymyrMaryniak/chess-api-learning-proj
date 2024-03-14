namespace ChessAPI.Models;

public class Error(string errorCode, string description)
{
    public string ErrorCode { get; } = errorCode;
    public string Description { get; } = description;
}
