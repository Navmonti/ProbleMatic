namespace ProbleMatic.Api.DTOs.Customers;

public record CreateCustomerRequest(string FirstName, string LastName, string Email, string PhoneNumber, Guid UserId);
