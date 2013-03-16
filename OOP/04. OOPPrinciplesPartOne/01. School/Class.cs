using System;
using System.Text;
using System.Collections.Generic;

class Class : ICommentable
{
    private readonly List<Teacher> classTeachers = new List<Teacher>();
    private readonly List<Student> classStudents = new List<Student>();
    private string className;

    public Class(string className)
    {
        this.ClassName = className;
    }

    public void AddTeacher(Teacher teacher)
    {
        this.classTeachers.Add(teacher);
    }

    public void AddStudent(Student student)
    {
        this.classStudents.Add(student);
    }

    public string ClassName
    {
        get { return this.className; }
        private set { this.className = value; }
    }

    public string Comment { get; set; } // ICommentable

    public override string ToString()
    {
        StringBuilder result = new StringBuilder();

        result.AppendLine(new string('-', 25));
        result.AppendLine("Class name: " + this.className);
        result.AppendLine("Teacher(s): " + this.classTeachers.Count);

        for (int i = 0, teachersIndex = 1; i < this.classTeachers.Count; i++, teachersIndex++)
        {
            result.AppendLine("[ " + teachersIndex + " - " + this.classTeachers[i] + " ]");
        }

        result.AppendLine(new string('-', 25));
        result.AppendLine("Student(s): " + this.classStudents.Count);

        for (int i = 0, studentsIndex = 1; i < this.classStudents.Count; i++, studentsIndex++)
        {
            result.AppendLine("[ " + studentsIndex + " - " + this.classStudents[i] + " ]");
        }

        result.AppendLine(new string('-', 25));

        return result.ToString();
    }
}