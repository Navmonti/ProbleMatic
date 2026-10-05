namespace ProbleMatic.Api.DTOs.Tickets;

public record CreateTicketRequest(string Title, string Description, string? Status);
