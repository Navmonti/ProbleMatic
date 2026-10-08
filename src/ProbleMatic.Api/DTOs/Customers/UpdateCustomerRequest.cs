namespace ProbleMatic.Api.DTOs.Customers;

public record UpdateCustomerRequest(string FirstName, string LastName, string Email, string PhoneNumber, Guid UserId);
