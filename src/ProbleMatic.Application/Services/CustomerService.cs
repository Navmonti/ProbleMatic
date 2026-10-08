using ProbleMatic.Application.Interfaces;
using ProbleMatic.Application.IRepositories;
using ProbleMatic.Domain.Entities;

namespace ProbleMatic.Application.Services;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerService(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<IEnumerable<Customer>> GetAllCustomersAsync(CancellationToken cancellationToken = default)
    {
        return await _customerRepository.GetAllAsync(cancellationToken);
    }

    public async Task<Customer?> GetCustomerByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _customerRepository.GetByIdAsync(id, cancellationToken);
    }

    public async Task<Customer> CreateCustomerAsync(string firstName, string lastName, string email, string phoneNumber, Guid userId, CancellationToken cancellationToken = default)
    {
        var customer = new Customer(firstName, lastName, email, phoneNumber, userId);
        await _customerRepository.AddAsync(customer, cancellationToken);
        await _customerRepository.SaveChangesAsync(cancellationToken);
        return customer;
    }

    public async Task UpdateCustomerAsync(Guid id, string firstName, string lastName, string email, string phoneNumber, Guid userId, CancellationToken cancellationToken = default)
    {
        var customer = await _customerRepository.GetByIdAsync(id, cancellationToken);

        if (customer is null)
        {
            throw new InvalidOperationException($"Customer with id {id} was not found.");
        }

        customer.UpdateProfile(firstName, lastName, email, phoneNumber, userId);
        await _customerRepository.UpdateAsync(customer, cancellationToken);
        await _customerRepository.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteCustomerAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var customer = await _customerRepository.GetByIdAsync(id, cancellationToken);

        if (customer is null)
        {
            throw new InvalidOperationException($"Customer with id {id} was not found.");
        }

        await _customerRepository.DeleteAsync(customer, cancellationToken);
        await _customerRepository.SaveChangesAsync(cancellationToken);
    }
}
