using ProbleMatic.Application.Interfaces;
using ProbleMatic.Application.IRepositories;
using ProbleMatic.Domain.Entities;

namespace ProbleMatic.Application.Services;

public class UserRoleService : IUserRoleService
{
    private readonly IUserRoleRepository _userRoleRepository;

    public UserRoleService(IUserRoleRepository userRoleRepository)
    {
        _userRoleRepository = userRoleRepository;
    }

    public async Task<IEnumerable<UserRole>> GetAllUserRolesAsync(CancellationToken cancellationToken = default)
    {
        return await _userRoleRepository.GetAllAsync(cancellationToken);
    }

    public async Task<UserRole?> GetUserRoleByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _userRoleRepository.GetByIdAsync(id, cancellationToken);
    }

    public async Task<UserRole> CreateUserRoleAsync(Guid userId, Guid roleId, CancellationToken cancellationToken = default)
    {
        var userRole = new UserRole(userId, roleId);
        await _userRoleRepository.AddAsync(userRole, cancellationToken);
        await _userRoleRepository.SaveChangesAsync(cancellationToken);
        return userRole;
    }

    public async Task UpdateUserRoleAsync(Guid id, Guid userId, Guid roleId, CancellationToken cancellationToken = default)
    {
        var userRole = await _userRoleRepository.GetByIdAsync(id, cancellationToken);

        if (userRole is null)
        {
            throw new InvalidOperationException($"User role with id {id} was not found.");
        }

        userRole.UpdateAssignment(userId, roleId);
        await _userRoleRepository.UpdateAsync(userRole, cancellationToken);
        await _userRoleRepository.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteUserRoleAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var userRole = await _userRoleRepository.GetByIdAsync(id, cancellationToken);

        if (userRole is null)
        {
            throw new InvalidOperationException($"User role with id {id} was not found.");
        }

        await _userRoleRepository.DeleteAsync(userRole, cancellationToken);
        await _userRoleRepository.SaveChangesAsync(cancellationToken);
    }
}
