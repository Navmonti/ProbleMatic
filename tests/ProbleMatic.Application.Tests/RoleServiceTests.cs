using ProbleMatic.Application.IRepositories;
using ProbleMatic.Application.Services;
using ProbleMatic.Domain.Entities;

namespace ProbleMatic.Application.Tests;

public class RoleServiceTests
{
    [Fact]
    public async Task CreateRoleAsync_ShouldCreateRole()
    {
        var repository = new FakeRoleRepository();
        var service = new RoleService(repository);

        var role = await service.CreateRoleAsync("Admin");

        Assert.Equal("Admin", role.Name);
        Assert.True(repository.Called);
    }

    private sealed class FakeRoleRepository : IRoleRepository
    {
        public bool Called { get; private set; }

        public Task<Role?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default) => Task.FromResult<Role?>(null);

        public Task<IEnumerable<Role>> GetAllAsync(CancellationToken cancellationToken = default) => Task.FromResult<IEnumerable<Role>>(new List<Role>());

        public Task AddAsync(Role entity, CancellationToken cancellationToken = default)
        {
            Called = true;
            return Task.CompletedTask;
        }

        public Task UpdateAsync(Role entity, CancellationToken cancellationToken = default) => Task.CompletedTask;

        public Task DeleteAsync(Role entity, CancellationToken cancellationToken = default) => Task.CompletedTask;

        public Task SaveChangesAsync(CancellationToken cancellationToken = default) => Task.CompletedTask;
    }
}
