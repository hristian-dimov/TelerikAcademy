using System;
using System.Linq;

public class Student
{
    private string name;
    private int studentNumber;

    public Student(string name, int studentNumber)
    {
        this.Name = name;
        this.StudentNumber = studentNumber;
    }

    public string Name
    {
        get
        {
            return this.name;
        }
        private set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Name cannot be empty");
            }

            this.name = value;
        }
    }

    public int StudentNumber
    {
        get
        {
            return this.studentNumber;
        }
        private set
        {
            if (value < 10000 || value > 99999)
            {
                throw new ArgumentException("Unique Number should be between 10000 and 99999.");
            }

            this.studentNumber = value;
        }
    }
}