using Microsoft.AspNetCore.Mvc;
using ProbleMatic.Api.DTOs;
using ProbleMatic.Application.Interfaces;

namespace ProbleMatic.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IUserService _userService;

    public AuthController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto request, CancellationToken cancellationToken)
    {
        var existingUser = (await _userService.GetAllUsersAsync(cancellationToken))
            .FirstOrDefault(user => user.Email.Equals(request.Email, StringComparison.OrdinalIgnoreCase));

        if (existingUser is not null)
        {
            return Conflict(new { message = "User already exists." });
        }

        var createdUser = await _userService.CreateUserAsync(
            request.FirstName,
            request.LastName,
            request.Email,
            request.PasswordHash,
            cancellationToken);

        return CreatedAtAction(nameof(Register), new { id = createdUser.Id }, new
        {
            createdUser.Id,
            createdUser.FirstName,
            createdUser.LastName,
            createdUser.Email
        });
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto request, CancellationToken cancellationToken)
    {
        var user = (await _userService.GetAllUsersAsync(cancellationToken))
            .FirstOrDefault(u =>
                u.Email.Equals(request.Email, StringComparison.OrdinalIgnoreCase) &&
                u.PasswordHash == request.PasswordHash);

        if (user is null)
        {
            return Unauthorized(new { message = "Invalid email or password." });
        }

        return Ok(new
        {
            user.Id,
            user.FirstName,
            user.LastName,
            user.Email,
            Message = "Login successful."
        });
    }

    [HttpPost("logout")]
    public IActionResult Logout()
    {
        return Ok(new { message = "Logout successful." });
    }

}
