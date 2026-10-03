using ProbleMatic.Application.Interfaces;
using ProbleMatic.Application.IRepositories;
using ProbleMatic.Domain.Entities;

namespace ProbleMatic.Application.Services;

public class RoleService : IRoleService
{
    private readonly IRoleRepository _roleRepository;

    public RoleService(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }

    public async Task<IEnumerable<Role>> GetAllRolesAsync(CancellationToken cancellationToken = default)
    {
        return await _roleRepository.GetAllAsync(cancellationToken);
    }

    public async Task<Role?> GetRoleByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _roleRepository.GetByIdAsync(id, cancellationToken);
    }

    public async Task<Role> CreateRoleAsync(string name, CancellationToken cancellationToken = default)
    {
        var role = new Role(name);
        await _roleRepository.AddAsync(role, cancellationToken);
        await _roleRepository.SaveChangesAsync(cancellationToken);
        return role;
    }

    public async Task UpdateRoleAsync(Guid id, string name, CancellationToken cancellationToken = default)
    {
        var role = await _roleRepository.GetByIdAsync(id, cancellationToken);

        if (role is null)
        {
            throw new InvalidOperationException($"Role with id {id} was not found.");
        }

        role.UpdateName(name);
        await _roleRepository.UpdateAsync(role, cancellationToken);
        await _roleRepository.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteRoleAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var role = await _roleRepository.GetByIdAsync(id, cancellationToken);

        if (role is null)
        {
            throw new InvalidOperationException($"Role with id {id} was not found.");
        }

        await _roleRepository.DeleteAsync(role, cancellationToken);
        await _roleRepository.SaveChangesAsync(cancellationToken);
    }
}
