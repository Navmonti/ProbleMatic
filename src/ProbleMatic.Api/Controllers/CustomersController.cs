using Microsoft.AspNetCore.Mvc;
using ProbleMatic.Api.DTOs.Customers;
using ProbleMatic.Application.Interfaces;

namespace ProbleMatic.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomersController : ControllerBase
{
    private readonly ICustomerService _customerService;

    public CustomersController(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var customers = (await _customerService.GetAllCustomersAsync(cancellationToken))
            .Select(customer => new CustomerResponse(
                customer.Id,
                customer.UserId,
                customer.FirstName,
                customer.LastName,
                customer.Email,
                customer.PhoneNumber,
                customer.CreatedAt));

        return Ok(customers);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
    {
        var customer = await _customerService.GetCustomerByIdAsync(id, cancellationToken);

        if (customer is null)
        {
            return NotFound();
        }

        return Ok(new CustomerResponse(
            customer.Id,
            customer.UserId,
            customer.FirstName,
            customer.LastName,
            customer.Email,
            customer.PhoneNumber,
            customer.CreatedAt));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCustomerRequest request, CancellationToken cancellationToken)
    {
        var customer = await _customerService.CreateCustomerAsync(
            request.FirstName,
            request.LastName,
            request.Email,
            request.PhoneNumber,
            request.UserId,
            cancellationToken);

        return CreatedAtAction(nameof(GetById), new { id = customer.Id }, new CustomerResponse(
            customer.Id,
            customer.UserId,
            customer.FirstName,
            customer.LastName,
            customer.Email,
            customer.PhoneNumber,
            customer.CreatedAt));
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateCustomerRequest request, CancellationToken cancellationToken)
    {
        await _customerService.UpdateCustomerAsync(
            id,
            request.FirstName,
            request.LastName,
            request.Email,
            request.PhoneNumber,
            request.UserId,
            cancellationToken);

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        await _customerService.DeleteCustomerAsync(id, cancellationToken);
        return NoContent();
    }
}
