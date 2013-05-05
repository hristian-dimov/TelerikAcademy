using System;

namespace Methods
{
    class Student
    {
        public Student(string firstName, string lastName, string homeTown, string birthDate)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.HomeTown = homeTown;
            this.BirthDate = DateTime.Parse(birthDate);
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string HomeTown { get; private set; }
        public DateTime BirthDate { get; private set; }

        public bool IsOlderThan(Student other)
        {
            DateTime firstDate = this.BirthDate;
            DateTime secondDate = other.BirthDate;

            bool isOlder = firstDate > secondDate;

            return isOlder;
        }
    }
}
