namespace ProbleMatic.Api.DTOs.Employees;

public record EmployeeResponse(Guid Id, string FirstName, string LastName, string Email, string JobTitle, DateTime CreatedAt);
