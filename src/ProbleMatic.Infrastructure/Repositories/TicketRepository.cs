using ProbleMatic.Application.IRepositories;
using ProbleMatic.Domain.Entities;
using ProbleMatic.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ProbleMatic.Infrastructure.Repositories;

public class TicketRepository : GenericRepository<Ticket>, ITicketRepository
{
    private readonly AppDbContext _context;

    public TicketRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    public Task AssignToEmployeeAsync(Ticket ticket, Guid employeeId, CancellationToken cancellationToken = default)
    {
        ticket.AssignToEmployee(employeeId);
        _context.Tickets.Update(ticket);
        return Task.CompletedTask;
    }

    public async Task<IEnumerable<Ticket>> GetByDepartmentIdAsync(Guid departmentId, CancellationToken cancellationToken = default)
    {
        return await _context.Tickets
            .AsNoTracking()
            .Where(ticket => ticket.DepartmentId == departmentId)
            .ToListAsync(cancellationToken);
    }
}
