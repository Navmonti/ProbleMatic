using Microsoft.Extensions.DependencyInjection;
using ProbleMatic.Application.Interfaces;
using ProbleMatic.Application.Services;

namespace ProbleMatic.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IDepartmentService, DepartmentService>();
        services.AddScoped<IRoleService, RoleService>();
        services.AddScoped<ITicketService, TicketService>();
        services.AddScoped<IUserRoleService, UserRoleService>();
        services.AddScoped<IUserService, UserService>();

        return services;
    }
}