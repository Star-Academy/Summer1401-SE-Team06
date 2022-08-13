namespace project;

public record Lesson
{
    public string Name { get; init; }
    public double Score { get; init; }
    public int StudentNumber { get; set; }
}