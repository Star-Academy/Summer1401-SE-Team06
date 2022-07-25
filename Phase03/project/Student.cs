namespace project
{
    public class Student
    {
        public int StudentNumber { get; set; }
        public double AverageGrade { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Lesson> Lessons{ get; set; } = new();

        public void AddLesson(Lesson lesson)
        {
            Lessons.Add(lesson);
            AverageGrade = Lessons.Select(x => x.score).Average();
        }
    }
}