using ProbleMatic.Domain.Entities;

namespace ProbleMatic.Application.Interfaces;

public interface ITicketService
{
    Task<IEnumerable<Ticket>> GetAllTicketsAsync(CancellationToken cancellationToken = default);
    Task<IEnumerable<Ticket>> GetTicketsByDepartmentAsync(Guid departmentId, CancellationToken cancellationToken = default);
    Task<Ticket?> GetTicketByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Ticket> CreateTicketAsync(
        string title,
        string description,
        Guid creatorUserId,
        Guid departmentId,
        Guid? assignedEmployeeId,
        string? status = null,
        CancellationToken cancellationToken = default);
    Task UpdateTicketAsync(
        Guid id,
        string title,
        string description,
        string status,
        Guid creatorUserId,
        Guid departmentId,
        Guid? assignedEmployeeId,
        CancellationToken cancellationToken = default);
    Task AssignTicketToEmployeeAsync(Guid ticketId, Guid employeeId, CancellationToken cancellationToken = default);
    Task DeleteTicketAsync(Guid id, CancellationToken cancellationToken = default);
}
