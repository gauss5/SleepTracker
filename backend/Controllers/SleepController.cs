using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SleepTracker.Data;
using SleepTracker.DTOs;
using SleepTracker.Models;

namespace SleepTracker.Controllers;

[ApiController]
[Route("api/sleep")]
[Authorize]
public class SleepController(AppDbContext db) : ControllerBase
{
    private int UserId => int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var records = await db.SleepRecords
            .Where(r => r.UserId == UserId)
            .OrderByDescending(r => r.SleepDate)
            .Select(r => new SleepRecordDto(
                r.Id, r.SleepDate, r.BedTime, r.WakeTime,
                r.Quality, r.Notes, r.DurationMinutes, r.DurationHours))
            .ToListAsync();

        return Ok(records);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var r = await db.SleepRecords.FirstOrDefaultAsync(r => r.Id == id && r.UserId == UserId);
        if (r is null) return NotFound();
        return Ok(new SleepRecordDto(r.Id, r.SleepDate, r.BedTime, r.WakeTime,
            r.Quality, r.Notes, r.DurationMinutes, r.DurationHours));
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateSleepDto dto)
    {
        var record = new SleepRecord
        {
            UserId = UserId,
            SleepDate = dto.SleepDate,
            BedTime = dto.BedTime,
            WakeTime = dto.WakeTime,
            Quality = dto.Quality,
            Notes = dto.Notes
        };
        db.SleepRecords.Add(record);
        await db.SaveChangesAsync();
        return Ok(new SleepRecordDto(record.Id, record.SleepDate, record.BedTime,
            record.WakeTime, record.Quality, record.Notes,
            record.DurationMinutes, record.DurationHours));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, CreateSleepDto dto)
    {
        var record = await db.SleepRecords.FirstOrDefaultAsync(r => r.Id == id && r.UserId == UserId);
        if (record is null) return NotFound();
        record.SleepDate = dto.SleepDate;
        record.BedTime = dto.BedTime;
        record.WakeTime = dto.WakeTime;
        record.Quality = dto.Quality;
        record.Notes = dto.Notes;
        await db.SaveChangesAsync();
        return Ok(new SleepRecordDto(record.Id, record.SleepDate, record.BedTime,
            record.WakeTime, record.Quality, record.Notes,
            record.DurationMinutes, record.DurationHours));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var record = await db.SleepRecords.FirstOrDefaultAsync(r => r.Id == id && r.UserId == UserId);
        if (record is null) return NotFound();
        db.SleepRecords.Remove(record);
        await db.SaveChangesAsync();
        return NoContent();
    }

    [HttpGet("stats")]
    public async Task<IActionResult> GetStats()
    {
        var records = await db.SleepRecords
            .Where(r => r.UserId == UserId)
            .ToListAsync();

        if (!records.Any())
            return Ok(new StatsDto("0h", "0", "0h", "0 dias"));

        // Média semanal (últimos 7 dias)
        var last7 = records
            .Where(r => r.SleepDate >= DateOnly.FromDateTime(DateTime.UtcNow.AddDays(-7)))
            .ToList();
        var weeklyAvgMin = last7.Any() ? last7.Average(r => r.DurationMinutes) : 0;
        var weeklyAvg = $"{(int)weeklyAvgMin / 60}h{(int)weeklyAvgMin % 60:D2}";

        // Qualidade média
        var avgQuality = records.Average(r => r.Quality).ToString("F1");

        // Melhor noite
        var best = records.Max(r => r.DurationMinutes);
        var bestNight = $"{best / 60}h{best % 60:D2}";

        // Sequência de dias consecutivos
        var dates = records.Select(r => r.SleepDate).Distinct().OrderByDescending(d => d).ToList();
        var streak = 0;
        var today = DateOnly.FromDateTime(DateTime.UtcNow);
        foreach (var d in dates)
        {
            if (d == today.AddDays(-streak)) streak++;
            else break;
        }

        return Ok(new StatsDto(weeklyAvg, avgQuality, bestNight, $"{streak} dias"));
    }
}