﻿namespace project;

public record Lesson
{
    public string Name { get; set; }
    public double Score { get; init; }
}