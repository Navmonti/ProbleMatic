using Microsoft.AspNetCore.Mvc;
using ProbleMatic.Application.Interfaces;

namespace ProbleMatic.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DepartmentsController : ControllerBase
{
    private readonly IDepartmentService _departmentService;

    public DepartmentsController(IDepartmentService departmentService)
    {
        _departmentService = departmentService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var departments = await _departmentService.GetAllDepartmentsAsync(cancellationToken);
        return Ok(departments);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
    {
        var department = await _departmentService.GetDepartmentByIdAsync(id, cancellationToken);

        if (department is null)
        {
            return NotFound();
        }

        return Ok(department);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateDepartmentRequest request, CancellationToken cancellationToken)
    {
        var department = await _departmentService.CreateDepartmentAsync(request.Name, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = department.Id }, department);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateDepartmentRequest request, CancellationToken cancellationToken)
    {
        await _departmentService.UpdateDepartmentAsync(id, request.Name, cancellationToken);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        await _departmentService.DeleteDepartmentAsync(id, cancellationToken);
        return NoContent();
    }

    public sealed record CreateDepartmentRequest(string Name);

    public sealed record UpdateDepartmentRequest(string Name);
}
