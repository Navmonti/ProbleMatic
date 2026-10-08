using ProbleMatic.Domain.Entities;

namespace ProbleMatic.Application.Interfaces;

public interface ICustomerService
{
    Task<IEnumerable<Customer>> GetAllCustomersAsync(CancellationToken cancellationToken = default);
    Task<Customer?> GetCustomerByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Customer> CreateCustomerAsync(string firstName, string lastName, string email, string phoneNumber, Guid userId, CancellationToken cancellationToken = default);
    Task UpdateCustomerAsync(Guid id, string firstName, string lastName, string email, string phoneNumber, Guid userId, CancellationToken cancellationToken = default);
    Task DeleteCustomerAsync(Guid id, CancellationToken cancellationToken = default);
}
