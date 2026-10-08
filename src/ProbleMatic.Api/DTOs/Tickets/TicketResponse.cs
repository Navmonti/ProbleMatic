namespace ProbleMatic.Api.DTOs.Tickets;

public record TicketResponse(
	Guid Id,
	string Title,
	string Description,
	string Status,
	Guid CreatorUserId,
	Guid DepartmentId,
	Guid? AssignedEmployeeId,
	DateTime CreatedAt);
