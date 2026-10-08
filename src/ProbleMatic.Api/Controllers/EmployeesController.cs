using Microsoft.AspNetCore.Mvc;
using ProbleMatic.Api.DTOs.Employees;
using ProbleMatic.Application.Interfaces;

namespace ProbleMatic.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeesController : ControllerBase
{
    private readonly IEmployeeService _employeeService;

    public EmployeesController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var employees = (await _employeeService.GetAllEmployeesAsync(cancellationToken))
            .Select(employee => new EmployeeResponse(
                employee.Id,
                employee.FirstName,
                employee.LastName,
                employee.Email,
                employee.JobTitle,
                employee.CreatedAt));

        return Ok(employees);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
    {
        var employee = await _employeeService.GetEmployeeByIdAsync(id, cancellationToken);

        if (employee is null)
        {
            return NotFound();
        }

        return Ok(new EmployeeResponse(
            employee.Id,
            employee.FirstName,
            employee.LastName,
            employee.Email,
            employee.JobTitle,
            employee.CreatedAt));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateEmployeeRequest request, CancellationToken cancellationToken)
    {
        var employee = await _employeeService.CreateEmployeeAsync(
            request.FirstName,
            request.LastName,
            request.Email,
            request.JobTitle,
            cancellationToken);

        return CreatedAtAction(nameof(GetById), new { id = employee.Id }, new EmployeeResponse(
            employee.Id,
            employee.FirstName,
            employee.LastName,
            employee.Email,
            employee.JobTitle,
            employee.CreatedAt));
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateEmployeeRequest request, CancellationToken cancellationToken)
    {
        await _employeeService.UpdateEmployeeAsync(
            id,
            request.FirstName,
            request.LastName,
            request.Email,
            request.JobTitle,
            cancellationToken);

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        await _employeeService.DeleteEmployeeAsync(id, cancellationToken);
        return NoContent();
    }
}
