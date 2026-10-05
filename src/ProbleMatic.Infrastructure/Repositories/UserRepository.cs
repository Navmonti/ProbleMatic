using ProbleMatic.Application.IRepositories;
using ProbleMatic.Domain.Entities;
using ProbleMatic.Infrastructure.Persistence;

namespace ProbleMatic.Infrastructure.Repositories;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(AppDbContext context) : base(context)
    {
    }
}
