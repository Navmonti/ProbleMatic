using ProbleMatic.Domain.Entities;

namespace ProbleMatic.Application.Interfaces;

public interface IUserService
{
    Task<IEnumerable<User>> GetAllUsersAsync(CancellationToken cancellationToken = default);
    Task<User?> GetUserByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<User> CreateUserAsync(string firstName, string lastName, string email, string passwordHash, CancellationToken cancellationToken = default);
    Task UpdateUserAsync(Guid id, string firstName, string lastName, string email, CancellationToken cancellationToken = default);
    Task DeleteUserAsync(Guid id, CancellationToken cancellationToken = default);
}
