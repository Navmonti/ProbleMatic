namespace ProbleMatic.Api.DTOs.Users;

public record UserResponse(Guid Id, string FirstName, string LastName, string Email, string PasswordHash, DateTime CreatedAt);
