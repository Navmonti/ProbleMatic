using ProbleMatic.Application.IRepositories;
using ProbleMatic.Domain.Entities;
using ProbleMatic.Infrastructure.Persistence;

namespace ProbleMatic.Infrastructure.Repositories;

public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
{
    public EmployeeRepository(AppDbContext context) : base(context)
    {
    }
}
