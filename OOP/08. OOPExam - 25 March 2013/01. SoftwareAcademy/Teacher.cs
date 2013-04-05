using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareAcademy
{
    public class Teacher : ITeacher
    {
        private string name;
        public IList<ICourse> TeacherCourses = new List<ICourse>();

        public Teacher(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get { return this.name; }
            set 
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException("Teacher name cannot be null");

                this.name = value; 
            }
        }
        
        public void AddCourse(ICourse course)
        {
            this.TeacherCourses.Add(course);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Teacher: Name=" + this.Name);
            if (this.TeacherCourses.Count > 0)
            {
                sb.Append("; Courses=[");
                foreach (var item in this.TeacherCourses)
                {
                    sb.Append(item.Name + ", ");
                }
                sb.Length -= 2;
                sb.Append("]");
            }

            return sb.ToString();
        }
    }
}
