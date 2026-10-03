using Microsoft.EntityFrameworkCore;
using ProbleMatic.Application.IRepositories;
using ProbleMatic.Domain.Entities;

namespace ProbleMatic.Infrastructure.Repositories;

public class UserRoleRepository : GenericRepository<UserRole>, IUserRoleRepository
{
    public UserRoleRepository(DbContext context) : base(context)
    {
    }
}
