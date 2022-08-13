namespace project;

public record Student
{
    public int StudentNumber { get; init; }
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public List<Lesson> Lessons { get; } = new();

    public double AverageGrade
    {
        get { return Lessons.Average(x => x.Score); }
    }

    public void RegisterLesson(Lesson lesson)
    {
        Lessons.Add(lesson);
    }
}
