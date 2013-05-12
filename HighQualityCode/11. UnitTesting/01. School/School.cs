using System;
using System.Collections.Generic;
using System.Linq;

public class School
{
    private string name;
    private readonly IList<Course> courses;

    public School(string name)
    {
        this.Name = name;
        this.courses = new List<Course>();
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

    public IList<Course> Courses
    {
        get
        {
            return this.courses;
        }
    }

    public void AddCourse(Course course)
    {
        if (course == null)
        {
            throw new ArgumentNullException("Course cannot be null.");
        }

        this.courses.Add(course);
    }

    public void RemoveCourse(Course course)
    {
        if (course == null)
        {
            throw new ArgumentNullException("Course cannot be null.");
        }

        this.courses.Remove(course);
    }
}