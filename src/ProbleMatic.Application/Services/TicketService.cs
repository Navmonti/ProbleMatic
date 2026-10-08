using ProbleMatic.Application.Interfaces;
using ProbleMatic.Application.IRepositories;
using ProbleMatic.Domain.Entities;

namespace ProbleMatic.Application.Services;

public class TicketService : ITicketService
{
    private readonly ITicketRepository _ticketRepository;
    private readonly IEmployeeRepository _employeeRepository;

    public TicketService(ITicketRepository ticketRepository, IEmployeeRepository employeeRepository)
    {
        _ticketRepository = ticketRepository;
        _employeeRepository = employeeRepository;
    }

    public async Task<IEnumerable<Ticket>> GetAllTicketsAsync(CancellationToken cancellationToken = default)
    {
        return await _ticketRepository.GetAllAsync(cancellationToken);
    }

    public async Task<IEnumerable<Ticket>> GetTicketsByDepartmentAsync(Guid departmentId, CancellationToken cancellationToken = default)
    {
        return await _ticketRepository.GetByDepartmentIdAsync(departmentId, cancellationToken);
    }

    public async Task<Ticket?> GetTicketByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _ticketRepository.GetByIdAsync(id, cancellationToken);
    }

    public async Task<Ticket> CreateTicketAsync(
        string title,
        string description,
        Guid creatorUserId,
        Guid departmentId,
        Guid? assignedEmployeeId,
        string? status = null,
        CancellationToken cancellationToken = default)
    {
        var ticket = new Ticket(title, description, creatorUserId, departmentId, assignedEmployeeId, status);
        await _ticketRepository.AddAsync(ticket, cancellationToken);
        await _ticketRepository.SaveChangesAsync(cancellationToken);
        return ticket;
    }

    public async Task UpdateTicketAsync(
        Guid id,
        string title,
        string description,
        string status,
        Guid creatorUserId,
        Guid departmentId,
        Guid? assignedEmployeeId,
        CancellationToken cancellationToken = default)
    {
        var ticket = await _ticketRepository.GetByIdAsync(id, cancellationToken);

        if (ticket is null)
        {
            throw new InvalidOperationException($"Ticket with id {id} was not found.");
        }

        ticket.Update(title, description, status, creatorUserId, departmentId, assignedEmployeeId);
        await _ticketRepository.UpdateAsync(ticket, cancellationToken);
        await _ticketRepository.SaveChangesAsync(cancellationToken);
    }

    public async Task AssignTicketToEmployeeAsync(Guid ticketId, Guid employeeId, CancellationToken cancellationToken = default)
    {
        var ticket = await _ticketRepository.GetByIdAsync(ticketId, cancellationToken);

        if (ticket is null)
        {
            throw new InvalidOperationException($"Ticket with id {ticketId} was not found.");
        }

        var employee = await _employeeRepository.GetByIdAsync(employeeId, cancellationToken);

        if (employee is null)
        {
            throw new InvalidOperationException($"Employee with id {employeeId} was not found.");
        }

        await _ticketRepository.AssignToEmployeeAsync(ticket, employeeId, cancellationToken);
        await _ticketRepository.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteTicketAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var ticket = await _ticketRepository.GetByIdAsync(id, cancellationToken);

        if (ticket is null)
        {
            throw new InvalidOperationException($"Ticket with id {id} was not found.");
        }

        await _ticketRepository.DeleteAsync(ticket, cancellationToken);
        await _ticketRepository.SaveChangesAsync(cancellationToken);
    }
}
