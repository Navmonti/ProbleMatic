namespace ProbleMatic.Api.DTOs;

public sealed record LoginDto(
    string Email,
    string PasswordHash);
