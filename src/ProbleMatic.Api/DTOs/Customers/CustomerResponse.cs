namespace ProbleMatic.Api.DTOs.Customers;

public record CustomerResponse(Guid Id, Guid UserId, string FirstName, string LastName, string Email, string PhoneNumber, DateTime CreatedAt);
