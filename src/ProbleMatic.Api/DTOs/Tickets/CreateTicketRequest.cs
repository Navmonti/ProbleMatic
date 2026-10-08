namespace ProbleMatic.Api.DTOs.Tickets;

public record CreateTicketRequest(
	string Title,
	string Description,
	Guid CreatorUserId,
	Guid DepartmentId,
	Guid? AssignedEmployeeId,
	string? Status);
