using System;

enum University { NBU, TU }
enum Specialty { Math, Physics, Law }
enum Faculty { Law, Mathematics }

class Student : ICloneable, IComparable<Student>
{
    public Student(string firstName, string middleName, string lastName, long ssn, string address, long phoneNumber, University university, Specialty specialty, Faculty faculty)
    {
        this.FirstName = firstName;
        this.MiddleName = middleName;
        this.LastName = lastName;
        this.SSN = ssn;
        this.Address = address;
        this.PhoneNumber = phoneNumber;
        this.University = university;
        this.Specialty = specialty;
        this.Faculty = faculty;
    }

    public string FirstName { get; private set; }
    public string MiddleName { get; private set; }
    public string LastName { get; private set; }
    public long SSN { get; private set; }
    public string Address { get; private set; }
    public long PhoneNumber { get; private set; }
    public string Course { get; private set; }
    public University University { get; private set; }
    public Specialty Specialty { get; private set; }
    public Faculty Faculty { get; private set; }

    public override bool Equals(object obj)
    {
        Student student = obj as Student;

        if ((object)student == null)
        {
            return false;
        }

        if (!Object.Equals(this.FirstName, student.FirstName))
        {
            return false;
        }

        if (!Object.Equals(this.LastName, student.LastName))
        {
            return false;
        }

        if (this.SSN != student.SSN)
        {
            return false;
        }

        return true;
    }

    public override int GetHashCode()
    {
        return this.SSN.GetHashCode() ^ this.Address.GetHashCode();
    }

    public static bool operator ==(Student fistStudent, Student secondStudent)
    {
        return Student.Equals(fistStudent, secondStudent);
    }

    public static bool operator !=(Student fistStudent, Student secondStudent)
    {
        return !(Student.Equals(fistStudent, secondStudent));
    }

    public override string ToString()
    {
        return string.Format("{0} {1} is studying {2} in {3}",
            this.FirstName, this.LastName, this.Specialty, this.University);
    }


    //Second Task
    object ICloneable.Clone()  // Implicit implementation
    {
        return this.Clone();
    }

    public Student Clone()
    {
        return new Student(this.FirstName,this.MiddleName, this.LastName, this.SSN, this.Address,
                            this.PhoneNumber, this.University, this.Specialty, this.Faculty);
    }

    public int CompareTo(Student student)
    {
        if (this.FirstName != student.FirstName)
        {
            return this.FirstName.CompareTo(student.FirstName);
        }

        if (this.MiddleName != student.MiddleName)
        {
            return this.MiddleName.CompareTo(student.MiddleName);
        }

        if (this.LastName != student.LastName)
        {
            return this.LastName.CompareTo(student.LastName);
        }

        return this.SSN.CompareTo(student.SSN);
    }
}