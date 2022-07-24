using Newtonsoft.Json;
using project;
using System.Net;

namespace Project
{
    class App
    {
        public static void Main(string[] args)
        {
            string studentsData = DownloadData("https://docs.code-star.ir/assets/files/students-7e48b111d2450c4a8dc0ffe4fc912c36.json");
            string scoresData = DownloadData("https://docs.code-star.ir/assets/files/scores-76885bff66d5238dfd0661c6ac6d74fc.json");

            List<Student> students = new List<Student>();

            dynamic studentsJson = JsonConvert.DeserializeObject(studentsData);
            foreach (var item in studentsJson)
            {
                students.Add(new Student { firstName = item.FirstName, lastName = item.LastName, studentNumber = item.StudentNumber });
            }

            dynamic scoresJson = JsonConvert.DeserializeObject(scoresData);
            foreach (var item in scoresJson)
            {
                var Student = students.Where(x => x.studentNumber == (int)item.StudentNumber);
                Student.ElementAt(0).AddLesson(new Lesson { name = item.Lesson, score = item.Score });
            }

            for (int i = 0; i < 3; i++)
            {
                var sortedStudents = students.OrderByDescending(x => x.averageGrade);
                Student student = sortedStudents.ElementAt(i);
                string name = student.firstName + " " + student.lastName;
                double averageScore = student.averageGrade;

                Console.WriteLine("Name: " + name + " | Average Score: " + averageScore);
                Console.WriteLine();
            }
        }

        public static string DownloadData(string URL)
        {
            using (WebClient wc = new WebClient())
            {
                return wc.DownloadString(URL);
            }
        }
    }
}