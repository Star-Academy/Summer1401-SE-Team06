﻿namespace project;

public record Student
{
    public int StudentNumber { get; init; }
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public double AverageGrade { get; set; }
}