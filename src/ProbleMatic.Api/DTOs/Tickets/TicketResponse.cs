namespace ProbleMatic.Api.DTOs.Tickets;

public record TicketResponse(Guid Id, string Title, string Description, string Status, DateTime CreatedAt);
