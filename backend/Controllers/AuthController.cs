using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SleepTracker.Data;
using SleepTracker.DTOs;
using SleepTracker.Models;
using SleepTracker.Services;

namespace SleepTracker.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController(AppDbContext db, TokenService tokenService) : ControllerBase
{
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterDto dto)
    {
        if (await db.Users.AnyAsync(u => u.Email == dto.Email))
            return BadRequest(new { message = "E-mail já cadastrado." });

        var user = new User
        {
            Name         = dto.Name,
            Email        = dto.Email,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password)
        };

        db.Users.Add(user);
        await db.SaveChangesAsync();

        var token = tokenService.Generate(user);
        return Ok(new AuthResponseDto(token, new UserDto(user.Id, user.Name, user.Email)));
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto dto)
    {
        var user = await db.Users.FirstOrDefaultAsync(u => u.Email == dto.Email);
        if (user is null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
            return Unauthorized(new { message = "E-mail ou senha incorretos." });

        var token = tokenService.Generate(user);
        return Ok(new AuthResponseDto(token, new UserDto(user.Id, user.Name, user.Email)));
    }
}
