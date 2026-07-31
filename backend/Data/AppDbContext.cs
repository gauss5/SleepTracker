using Microsoft.EntityFrameworkCore;
using SleepTracker.Models;

namespace SleepTracker.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<User> Users => Set<User>();
    public DbSet<SleepRecord> SleepRecords => Set<SleepRecord>();

    protected override void OnModelCreating(ModelBuilder mb)
    {
        mb.Entity<User>(e =>
        {
            e.ToTable("Users");
            e.HasKey(u => u.Id);
            e.HasIndex(u => u.Email).IsUnique();
            e.Property(u => u.Name).IsRequired().HasMaxLength(100);
            e.Property(u => u.Email).IsRequired().HasMaxLength(200);
            e.Property(u => u.PasswordHash).IsRequired();
         
        });

        mb.Entity<SleepRecord>(e =>
        {
            e.HasOne(r => r.User)
             .WithMany(u => u.SleepRecords)
             .HasForeignKey(r => r.UserId)
             .OnDelete(DeleteBehavior.Cascade);

            e.Property(r => r.Quality).HasColumnType("tinyint");
            e.Ignore(r => r.DurationMinutes);
            e.Ignore(r => r.DurationHours);
        });
    }
}