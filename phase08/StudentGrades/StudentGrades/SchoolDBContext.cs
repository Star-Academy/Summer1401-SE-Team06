using Microsoft.EntityFrameworkCore;
using project;

namespace Repository;

public class SchoolDBContext : DbContext
{
    public DbSet<Student> Students { get; set; }
    public DbSet<StudentGrade> StudentGrades { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(
            @"Server=localhost;Port=5432;Database=SchoolDatabase1;Username=postgres;Password=alibnz5001");
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Student>().HasKey(p => p.StudentNumber);
        modelBuilder.Entity<StudentGrade>().HasKey(p => new { p.StudentNumber, p.Lesson });
    }
}