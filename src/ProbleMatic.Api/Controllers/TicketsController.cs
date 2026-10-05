using Microsoft.AspNetCore.Mvc;
using ProbleMatic.Api.DTOs.Tickets;
using ProbleMatic.Application.Interfaces;

namespace ProbleMatic.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TicketsController : ControllerBase
{
    private readonly ITicketService _ticketService;

    public TicketsController(ITicketService ticketService)
    {
        _ticketService = ticketService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var tickets = (await _ticketService.GetAllTicketsAsync(cancellationToken))
            .Select(ticket => new TicketResponse(ticket.Id, ticket.Title, ticket.Description, ticket.Status, ticket.CreatedAt));

        return Ok(tickets);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
    {
        var ticket = await _ticketService.GetTicketByIdAsync(id, cancellationToken);

        if (ticket is null)
        {
            return NotFound();
        }

        return Ok(new TicketResponse(ticket.Id, ticket.Title, ticket.Description, ticket.Status, ticket.CreatedAt));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateTicketRequest request, CancellationToken cancellationToken)
    {
        var ticket = await _ticketService.CreateTicketAsync(request.Title, request.Description, request.Status, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = ticket.Id }, new TicketResponse(ticket.Id, ticket.Title, ticket.Description, ticket.Status, ticket.CreatedAt));
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateTicketRequest request, CancellationToken cancellationToken)
    {
        await _ticketService.UpdateTicketAsync(id, request.Title, request.Description, request.Status, cancellationToken);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        await _ticketService.DeleteTicketAsync(id, cancellationToken);
        return NoContent();
    }
}
