namespace ProbleMatic.Api.DTOs.Users;

public record CreateUserRequest(string FirstName, string LastName, string Email, string PasswordHash);
