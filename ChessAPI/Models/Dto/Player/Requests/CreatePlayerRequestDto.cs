﻿namespace ChessAPI.Models.Dto.Player.Requests;

public class CreatePlayerRequestDto
{
    public required string UserName { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
}
