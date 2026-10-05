using ProbleMatic.Application.Interfaces;
using ProbleMatic.Application.IRepositories;
using ProbleMatic.Domain.Entities;

namespace ProbleMatic.Application.Services;

public class TicketService : ITicketService
{
    private readonly ITicketRepository _ticketRepository;

    public TicketService(ITicketRepository ticketRepository)
    {
        _ticketRepository = ticketRepository;
    }

    public async Task<IEnumerable<Ticket>> GetAllTicketsAsync(CancellationToken cancellationToken = default)
    {
        return await _ticketRepository.GetAllAsync(cancellationToken);
    }

    public async Task<Ticket?> GetTicketByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _ticketRepository.GetByIdAsync(id, cancellationToken);
    }

    public async Task<Ticket> CreateTicketAsync(string title, string description, string? status = null, CancellationToken cancellationToken = default)
    {
        var ticket = new Ticket(title, description, status);
        await _ticketRepository.AddAsync(ticket, cancellationToken);
        await _ticketRepository.SaveChangesAsync(cancellationToken);
        return ticket;
    }

    public async Task UpdateTicketAsync(Guid id, string title, string description, string status, CancellationToken cancellationToken = default)
    {
        var ticket = await _ticketRepository.GetByIdAsync(id, cancellationToken);

        if (ticket is null)
        {
            throw new InvalidOperationException($"Ticket with id {id} was not found.");
        }

        ticket.Update(title, description, status);
        await _ticketRepository.UpdateAsync(ticket, cancellationToken);
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
