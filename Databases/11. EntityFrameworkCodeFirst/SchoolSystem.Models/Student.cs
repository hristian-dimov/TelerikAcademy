using System;
using System.Collections.Generic;

namespace SchoolSystem.Models
{
    public class Student
    {
        private ICollection<Course> courseAttending;

        public Student()
        {
            this.courseAttending = new HashSet<Course>();
        }

        public int StudentId { get; set; }

        public string Name { get; set; }

        public string Number { get; set; }

        public virtual ICollection<Course> CourseAttending
        {
            get { return this.courseAttending; }
            set { this.courseAttending = value; }
        }
    }   
}
