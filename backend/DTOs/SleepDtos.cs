namespace SleepTracker.DTOs;

public record CreateSleepDto(
    DateOnly SleepDate,
    TimeOnly BedTime,
    TimeOnly WakeTime,
    int Quality,
    string? Notes
);

public record UpdateSleepDto(
    DateOnly SleepDate,
    TimeOnly BedTime,
    TimeOnly WakeTime,
    int Quality,
    string? Notes
);

public record SleepRecordDto(
    int Id,
    DateOnly SleepDate,
    TimeOnly BedTime,
    TimeOnly WakeTime,
    int Quality,
    string? Notes,
    int DurationHours,
    int DurationMinutes
);

public record StatsDto(
    string WeeklyAvg,
    string AvgQuality,
    string BestNight,
    string Streak
);