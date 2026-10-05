using ProbleMatic.Application.IRepositories;
using ProbleMatic.Domain.Entities;
using ProbleMatic.Infrastructure.Persistence;

namespace ProbleMatic.Infrastructure.Repositories;

public class TicketRepository : GenericRepository<Ticket>, ITicketRepository
{
    public TicketRepository(AppDbContext context) : base(context)
    {
    }
}
