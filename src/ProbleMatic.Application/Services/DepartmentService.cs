using ProbleMatic.Application.Interfaces;
using ProbleMatic.Application.IRepositories;
using ProbleMatic.Domain.Entities;

namespace ProbleMatic.Application.Services;

public class DepartmentService : IDepartmentService
{
    private readonly IDepartmentRepository _departmentRepository;

    public DepartmentService(IDepartmentRepository departmentRepository)
    {
        _departmentRepository = departmentRepository;
    }

    public async Task<IEnumerable<Department>> GetAllDepartmentsAsync(CancellationToken cancellationToken = default)
    {
        return await _departmentRepository.GetAllAsync(cancellationToken);
    }

    public async Task<Department?> GetDepartmentByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _departmentRepository.GetByIdAsync(id, cancellationToken);
    }

    public async Task<Department> CreateDepartmentAsync(string name, CancellationToken cancellationToken = default)
    {
        var department = new Department(name);
        await _departmentRepository.AddAsync(department, cancellationToken);
        await _departmentRepository.SaveChangesAsync(cancellationToken);
        return department;
    }

    public async Task UpdateDepartmentAsync(Guid id, string name, CancellationToken cancellationToken = default)
    {
        var department = await _departmentRepository.GetByIdAsync(id, cancellationToken);

        if (department is null)
        {
            throw new InvalidOperationException($"Department with id {id} was not found.");
        }

        department.UpdateName(name);
        await _departmentRepository.UpdateAsync(department, cancellationToken);
        await _departmentRepository.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteDepartmentAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var department = await _departmentRepository.GetByIdAsync(id, cancellationToken);

        if (department is null)
        {
            throw new InvalidOperationException($"Department with id {id} was not found.");
        }

        await _departmentRepository.DeleteAsync(department, cancellationToken);
        await _departmentRepository.SaveChangesAsync(cancellationToken);
    }
}
