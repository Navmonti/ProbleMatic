using ProbleMatic.Domain.Entities;

namespace ProbleMatic.Application.Interfaces;

public interface IEmployeeService
{
    Task<IEnumerable<Employee>> GetAllEmployeesAsync(CancellationToken cancellationToken = default);
    Task<Employee?> GetEmployeeByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Employee> CreateEmployeeAsync(string firstName, string lastName, string email, string jobTitle, CancellationToken cancellationToken = default);
    Task UpdateEmployeeAsync(Guid id, string firstName, string lastName, string email, string jobTitle, CancellationToken cancellationToken = default);
    Task DeleteEmployeeAsync(Guid id, CancellationToken cancellationToken = default);
}
