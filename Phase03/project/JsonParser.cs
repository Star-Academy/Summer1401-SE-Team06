﻿using Newtonsoft.Json;

namespace project;

public class JsonParser
{
    public List<Student> ParseStudents(string studentsData)
    {
        var studentsJson = JsonConvert.DeserializeObject<List<Student>>(studentsData);
        // foreach (var item in studentsJson)
        //     students.Add(new Student
        //         { FirstName = item.FirstName, LastName = item.LastName, StudentNumber = item.StudentNumber });
        return studentsJson;
    }

    public List<Student> ParseScores(List<Student> students, string scoresData)
    {
        dynamic scoresJson = JsonConvert.DeserializeObject(scoresData);
        foreach (var item in scoresJson)
        {
            var student = students.Where(x => x.StudentNumber == (int) item.StudentNumber);
            student.ElementAt(0).AddLesson(new Lesson { Name = item.Lesson, Score = item.Score });
        }

        return students;
    }
}