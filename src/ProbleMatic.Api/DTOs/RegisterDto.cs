namespace ProbleMatic.Api.DTOs;

public sealed record RegisterDto(
    string FirstName,
    string LastName,
    string Email,
    string PasswordHash);
