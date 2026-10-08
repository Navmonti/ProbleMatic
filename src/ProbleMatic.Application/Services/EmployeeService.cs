using ProbleMatic.Application.Interfaces;
using ProbleMatic.Application.IRepositories;
using ProbleMatic.Domain.Entities;

namespace ProbleMatic.Application.Services;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeeService(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public async Task<IEnumerable<Employee>> GetAllEmployeesAsync(CancellationToken cancellationToken = default)
    {
        return await _employeeRepository.GetAllAsync(cancellationToken);
    }

    public async Task<Employee?> GetEmployeeByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _employeeRepository.GetByIdAsync(id, cancellationToken);
    }

    public async Task<Employee> CreateEmployeeAsync(string firstName, string lastName, string email, string jobTitle, CancellationToken cancellationToken = default)
    {
        var employee = new Employee(firstName, lastName, email, jobTitle);
        await _employeeRepository.AddAsync(employee, cancellationToken);
        await _employeeRepository.SaveChangesAsync(cancellationToken);
        return employee;
    }

    public async Task UpdateEmployeeAsync(Guid id, string firstName, string lastName, string email, string jobTitle, CancellationToken cancellationToken = default)
    {
        var employee = await _employeeRepository.GetByIdAsync(id, cancellationToken);

        if (employee is null)
        {
            throw new InvalidOperationException($"Employee with id {id} was not found.");
        }

        employee.UpdateProfile(firstName, lastName, email, jobTitle);
        await _employeeRepository.UpdateAsync(employee, cancellationToken);
        await _employeeRepository.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteEmployeeAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var employee = await _employeeRepository.GetByIdAsync(id, cancellationToken);

        if (employee is null)
        {
            throw new InvalidOperationException($"Employee with id {id} was not found.");
        }

        await _employeeRepository.DeleteAsync(employee, cancellationToken);
        await _employeeRepository.SaveChangesAsync(cancellationToken);
    }
}
