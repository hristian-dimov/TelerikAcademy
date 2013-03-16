using System;

class Student : Person
{
    private int classNumber;

    public Student(string name, int classNumber) : base(name)
    {
        this.ClassNumber = classNumber;
    }

    public int ClassNumber {
        get { return this.classNumber; }
        private set { this.classNumber = value; }
    }

    public override string ToString()
    {
        return string.Format("Name: {0} - Class number: {1}",
            this.Name, this.ClassNumber);
    }
}