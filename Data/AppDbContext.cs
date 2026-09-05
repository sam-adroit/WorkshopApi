using Microsoft.EntityFrameworkCore;
using WorkshopApi.Models;

namespace WorkshopApi.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Workshop> Workshops => Set<Workshop>();
        public DbSet<Registration> Registrations => Set<Registration>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Registration>()
                .HasIndex(r => new { r.WorkshopId, r.StudentId })
                .IsUnique();

            modelBuilder.Entity<Workshop>().HasData(
                new Workshop
                {
                    Id = 1,
                    Title = "Introduction to C#",
                    Description = "Learn the basics of C# programming.",
                    Date = new DateTime(2026, 10, 15, 14, 0, 0, DateTimeKind.Utc),
                    Venue = "Room 101",
                    Capacity = 20,
                    RegistrationDeadline = new DateTime(2026, 10, 14, 23, 59, 0, DateTimeKind.Utc)
                },
                new Workshop
                {
                    Id = 2,
                    Title = "PostgreSQL Essentials",
                    Description = "Build practical PostgreSQL skills.",
                    Date = new DateTime(2026, 11, 5, 15, 0, 0, DateTimeKind.Utc),
                    Venue = "Lab 2",
                    Capacity = 15,
                    RegistrationDeadline = new DateTime(2026, 11, 4, 23, 59, 0, DateTimeKind.Utc)
                });
        }
    }
}
