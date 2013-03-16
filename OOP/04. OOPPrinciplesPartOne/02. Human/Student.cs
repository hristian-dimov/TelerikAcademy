using System;

class Student : Human
{
    private byte grade;

    public Student(string firstName, string secondName, byte grade)
        : base(firstName, secondName)
    {
        this.Grade = grade;
    }

    public byte Grade
    {
        get
        {
            return this.grade;
        }
        set
        {
            this.grade = value;
        }
    }

    public override string ToString()
    {
        return string.Format("{0} {1} - {2} grade",
            this.FirstName, this.LastName, this.Grade);
    }
}