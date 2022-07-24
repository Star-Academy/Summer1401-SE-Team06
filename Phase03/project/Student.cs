namespace project
{
    internal class Student
    {
        public int studentNumber { get; set; }
        public double averageGrade { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        private List<Lesson> lessons = new List<Lesson>();

        public void AddLesson(Lesson lesson)
        {
            lessons.Add(lesson);
            averageGrade = lessons.Select(x => x.score).Average();
        }
    }
}