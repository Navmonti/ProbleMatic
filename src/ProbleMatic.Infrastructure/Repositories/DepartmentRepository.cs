using Microsoft.EntityFrameworkCore;
using ProbleMatic.Application.IRepositories;
using ProbleMatic.Domain.Entities;

namespace ProbleMatic.Infrastructure.Repositories;

public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
{
    public DepartmentRepository(DbContext context) : base(context)
    {
    }
}
