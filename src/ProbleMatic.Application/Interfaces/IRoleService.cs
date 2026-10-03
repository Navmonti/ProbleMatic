using ProbleMatic.Domain.Entities;

namespace ProbleMatic.Application.Interfaces;

public interface IRoleService
{
    Task<IEnumerable<Role>> GetAllRolesAsync(CancellationToken cancellationToken = default);
    Task<Role?> GetRoleByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Role> CreateRoleAsync(string name, CancellationToken cancellationToken = default);
    Task UpdateRoleAsync(Guid id, string name, CancellationToken cancellationToken = default);
    Task DeleteRoleAsync(Guid id, CancellationToken cancellationToken = default);
}
