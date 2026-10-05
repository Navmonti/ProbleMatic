using Microsoft.AspNetCore.Mvc;
using ProbleMatic.Api.DTOs.UserRoles;
using ProbleMatic.Application.Interfaces;

namespace ProbleMatic.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserRolesController : ControllerBase
{
    private readonly IUserRoleService _userRoleService;

    public UserRolesController(IUserRoleService userRoleService)
    {
        _userRoleService = userRoleService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var userRoles = (await _userRoleService.GetAllUserRolesAsync(cancellationToken))
            .Select(userRole => new UserRoleResponse(userRole.Id, userRole.UserId, userRole.RoleId, userRole.CreatedAt));

        return Ok(userRoles);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
    {
        var userRole = await _userRoleService.GetUserRoleByIdAsync(id, cancellationToken);

        if (userRole is null)
        {
            return NotFound();
        }

        return Ok(new UserRoleResponse(userRole.Id, userRole.UserId, userRole.RoleId, userRole.CreatedAt));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateUserRoleRequest request, CancellationToken cancellationToken)
    {
        var userRole = await _userRoleService.CreateUserRoleAsync(request.UserId, request.RoleId, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = userRole.Id }, new UserRoleResponse(userRole.Id, userRole.UserId, userRole.RoleId, userRole.CreatedAt));
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateUserRoleRequest request, CancellationToken cancellationToken)
    {
        await _userRoleService.UpdateUserRoleAsync(id, request.UserId, request.RoleId, cancellationToken);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        await _userRoleService.DeleteUserRoleAsync(id, cancellationToken);
        return NoContent();
    }
}
