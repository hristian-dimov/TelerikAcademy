using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareAcademy
{
    public abstract class Course : ICourse
    {
        private string name;
        public IList<string> Topics = new List<string>();

        public Course(string name, ITeacher teacher = null)
        {
            this.Name = name;
            this.Teacher = teacher;
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException("Course name cannot be null");

                this.name = value;
            }
        }

        public ITeacher Teacher { get; set; }

        public void AddTopic(string topic)
        {
            this.Topics.Add(topic);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Name=" + this.Name);

            if (this.Teacher != null)
            {
                sb.Append("; Teacher=" + this.Teacher.Name);
            }

            if (this.Topics.Count > 0)
            {
                sb.Append("; Topics=[");
                foreach (var item in this.Topics)
                {
                    sb.Append(item + ", ");
                }
                sb.Length -= 2;
                sb.Append("]");
            }

            return sb.ToString();
        }
    }
}
