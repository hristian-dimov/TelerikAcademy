using System;

class Discipline : ICommentable
{
    private string name;
    private int lecturesCount;
    private int exerciseCount;

    public Discipline(string name, int lecturesCount, int exerciseCount)
    {
        this.Name = name;
        this.LecturesCount = lecturesCount;
        this.ExerciseCount = exerciseCount;
    }

    public string Name
    {
        get { return this.name; }
        private set { this.name = value; }
    }

    public int LecturesCount
    {
        get { return this.lecturesCount; }
        private set { this.lecturesCount = value; }
    }

    public int ExerciseCount
    {
        get { return this.exerciseCount; }
        private set { this.exerciseCount = value; }
    }

    public string Comment { get; set; } // ICommentable

    public override string ToString()
    {
        return this.Name;
    }
}