namespace ProbleMatic.Api.DTOs.Tickets;

public record UpdateTicketRequest(
	string Title,
	string Description,
	Guid CreatorUserId,
	Guid DepartmentId,
	Guid? AssignedEmployeeId,
	string Status);
