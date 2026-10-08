using ProbleMatic.Application.IRepositories;
using ProbleMatic.Domain.Entities;
using ProbleMatic.Infrastructure.Persistence;

namespace ProbleMatic.Infrastructure.Repositories;

public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
{
    public CustomerRepository(AppDbContext context) : base(context)
    {
    }
}
