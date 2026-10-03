using ProbleMatic.Domain.Entities;

namespace ProbleMatic.Application.Interfaces;

public interface IUserRoleService
{
    Task<IEnumerable<UserRole>> GetAllUserRolesAsync(CancellationToken cancellationToken = default);
    Task<UserRole?> GetUserRoleByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<UserRole> CreateUserRoleAsync(Guid userId, Guid roleId, CancellationToken cancellationToken = default);
    Task UpdateUserRoleAsync(Guid id, Guid userId, Guid roleId, CancellationToken cancellationToken = default);
    Task DeleteUserRoleAsync(Guid id, CancellationToken cancellationToken = default);
}
