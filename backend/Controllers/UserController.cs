using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SleepTracker.Data;
using SleepTracker.DTOs;

namespace SleepTracker.Controllers;

[ApiController]
[Route("api/user")]
[Authorize]
public class UserController(AppDbContext db) : ControllerBase
{
    private int UserId => int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

    [HttpGet("profile")]
    public async Task<IActionResult> GetProfile()
    {
        var user = await db.Users.FindAsync(UserId);
        if (user is null) return NotFound();
        return Ok(new UserDto(user.Id, user.Name, user.Email));
    }

    [HttpPut("profile")]
    public async Task<IActionResult> UpdateProfile(UpdateProfileDto dto)
    {
        var user = await db.Users.FindAsync(UserId);
        if (user is null) return NotFound();

        if (dto.Email != user.Email && await db.Users.AnyAsync(u => u.Email == dto.Email && u.Id != UserId))
            return BadRequest(new { message = "E-mail já está em uso." });

        user.Name  = dto.Name;
        user.Email = dto.Email;

        if (!string.IsNullOrEmpty(dto.Password))
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password);

        await db.SaveChangesAsync();
        return Ok(new UserDto(user.Id, user.Name, user.Email));
    }
}
