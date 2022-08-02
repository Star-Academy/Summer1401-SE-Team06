namespace project;

public record Student
{
    public int StudentNumber { get; init; }
    public double AverageGrade { get; set; }
    public string FirstName { get; init; }
    public string LastName { get; init; }
    private List<Lesson> Lessons { get; } = new();

    public void AddLesson(Lesson lesson)
    {
        Lessons.Add(lesson);
        AverageGrade = Lessons.Average(x => x.Score);
    }
}