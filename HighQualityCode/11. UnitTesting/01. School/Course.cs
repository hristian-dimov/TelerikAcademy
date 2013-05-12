using System;
using System.Collections.Generic;
using System.Linq;

public class Course
{
    public const int MaxStudentsInCourse = 30;

    private string courseName;
    private readonly IList<Student> studentsList;

    public Course(string courseName)
    {
        this.CourseName = courseName;
        this.studentsList = new List<Student>();
    }

    public string CourseName
    {
        get
        {
            return this.courseName;
        }
        private set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Name cannot be empty");
            }

            this.courseName = value;
        }
    }

    public IList<Student> StudentsList
    {
        get
        {
            return this.studentsList;
        }
    }

    public void JoinCourse(Student student)
    {
        if (student == null)
        {
            throw new ArgumentNullException("Student cannot be null!");
        }

        if (this.StudentsList.Count == MaxStudentsInCourse)
        {
            throw new InvalidOperationException("This course can't have more than 30 students");
        }

        foreach (Student st in this.StudentsList)
        {
            if (st.StudentNumber == student.StudentNumber)
            {
                throw new ArgumentException("Student is already in this course.");
            }
        }

        this.StudentsList.Add(student);
    }

    public void LeaveCourse(Student student)
    {
        if (student == null)
        {
            throw new ArgumentNullException("Student cannot be null!");
        }

        if (!this.StudentsList.Contains(student))
        {
            throw new InvalidOperationException("This student is not in the course!");
        }

        this.StudentsList.Remove(student);
    }

}