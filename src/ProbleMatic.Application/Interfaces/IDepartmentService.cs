using ProbleMatic.Domain.Entities;

namespace ProbleMatic.Application.Interfaces;

public interface IDepartmentService
{
    Task<IEnumerable<Department>> GetAllDepartmentsAsync(CancellationToken cancellationToken = default);
    Task<Department?> GetDepartmentByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Department> CreateDepartmentAsync(string name, CancellationToken cancellationToken = default);
    Task UpdateDepartmentAsync(Guid id, string name, CancellationToken cancellationToken = default);
    Task DeleteDepartmentAsync(Guid id, CancellationToken cancellationToken = default);
}
