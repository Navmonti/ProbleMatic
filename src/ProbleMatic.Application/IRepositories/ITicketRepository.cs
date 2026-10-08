using ProbleMatic.Domain.Entities;

namespace ProbleMatic.Application.IRepositories;

public interface ITicketRepository : IGenericRepository<Ticket>
{
	Task AssignToEmployeeAsync(Ticket ticket, Guid employeeId, CancellationToken cancellationToken = default);
    Task<IEnumerable<Ticket>> GetByDepartmentIdAsync(Guid departmentId, CancellationToken cancellationToken = default);
}
