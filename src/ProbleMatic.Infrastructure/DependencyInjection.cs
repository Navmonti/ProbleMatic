using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProbleMatic.Application.IRepositories;
using ProbleMatic.Infrastructure.Repositories;

namespace ProbleMatic.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IDepartmentRepository, DepartmentRepository>();
        services.AddScoped<IRoleRepository, RoleRepository>();
        services.AddScoped<IUserRoleRepository, UserRoleRepository>();
        return services;
    }
}