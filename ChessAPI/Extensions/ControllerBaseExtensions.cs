using ChessAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ChessAPI.Extensions;

public static class ControllerBaseExtensions
{
    public static BadRequestObjectResult BadRequestWithErrorDetails(this ControllerBase @this, Error error)
    {
        @this.ModelState.AddModelError(error.ErrorCode, error.Description);
        return @this.BadRequest(@this.ModelState);
    }
}
