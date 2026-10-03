using Microsoft.EntityFrameworkCore;
using ProbleMatic.Application.IRepositories;
using ProbleMatic.Domain.Entities;

namespace ProbleMatic.Infrastructure.Repositories;

public class RoleRepository : GenericRepository<Role>, IRoleRepository
{
    public RoleRepository(DbContext context) : base(context)
    {
    }
}
