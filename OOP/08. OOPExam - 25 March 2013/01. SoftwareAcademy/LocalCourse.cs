using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareAcademy
{
    public class LocalCourse : Course, ILocalCourse
    {
        private string lab;

        public LocalCourse(string name, ITeacher teacher, string lab = null)
            : base(name, teacher)
        {
            this.Lab = lab;
        }

        public string Lab
        {
            get { return this.lab; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException("Lab cannot be null");

                this.lab = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("LocalCourse: ");
            sb.Append(base.ToString());
            if (this.Lab != null)
            {
                sb.Append("; Lab=" + this.Lab);
            }
            return sb.ToString();
        }
    }
}
