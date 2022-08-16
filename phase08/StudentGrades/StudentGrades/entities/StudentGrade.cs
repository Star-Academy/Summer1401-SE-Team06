using System.ComponentModel.DataAnnotations.Schema;

namespace project;

public record StudentGrade
{
    public string Lesson { get; init; }
    public double Score { get; init; }

    [ForeignKey("Student")] public int StudentNumber { get; set; }
}