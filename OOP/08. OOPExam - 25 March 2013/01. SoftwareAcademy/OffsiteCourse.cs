using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareAcademy
{
    public class OffsiteCourse : Course, IOffsiteCourse
    {
        private string town;

        public OffsiteCourse(string name, ITeacher teacher, string town = null)
            : base(name, teacher)
        {
            this.Town = town;
        }

        public string Town
        {
            get { return this.town; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException("Town cannot be null");

                this.town = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("OffsiteCourse: ");
            sb.Append(base.ToString());
            if (this.Town != null)
            {
                sb.Append("; Town=" + this.Town);
            }
            return sb.ToString();
        }
    }
}
