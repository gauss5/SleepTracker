namespace SleepTracker.Models;

public class SleepRecord
{
    public int      Id               { get; set; }
    public int      UserId           { get; set; }
    public DateOnly SleepDate        { get; set; }
    public TimeOnly BedTime          { get; set; }
    public TimeOnly WakeTime         { get; set; }
    public int      Quality          { get; set; }  // 1–10
    public string?  Notes            { get; set; }
    public DateTime CreatedAt        { get; set; } = DateTime.UtcNow;

    // Calculados
    public int DurationMinutes => (int)(WakeTime.ToTimeSpan() - BedTime.ToTimeSpan()).TotalMinutes;
    public int DurationHours   => DurationMinutes / 60;

    public User User { get; set; } = null!;
}
