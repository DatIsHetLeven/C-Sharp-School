using System;
using System.Collections.Generic;
using System.Text;

public enum PracticalGrade
{
    None,
    Absent,
    Insufficient,
    Sufficient,
    Good
}
public class Course
{
    public string Name;
    public int Grade;
    public PracticalGrade Practical;

    public bool Passed()
    {
        return Grade >= 55 && Practical >= PracticalGrade.Sufficient;
    }
    public bool CamLaude()
    {
        return Grade >= 80 && Practical >= PracticalGrade.Good;
    }
}