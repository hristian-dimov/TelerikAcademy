using System;

class Student : IComparable<Student>
{
    private string firstName;
    private string lastName;

    public Student(string firstName, string lastName)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
    }

    public string FirstName
    {
        get { return this.firstName; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException("First name cannot be null.");
            }

            this.firstName = value;
        }
    }

    public string LastName
    {
        get { return this.lastName; }
        set 
        {
            if(string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException("Last name cannot be null.");
            }

            this.lastName = value; 
        }
    }

    public int CompareTo(Student other)
    {
        int compareResult = this.FirstName.CompareTo(other.FirstName);
        if (compareResult == 0)
        {
            compareResult = this.LastName.CompareTo(other.LastName);
        }

        return compareResult;
    }

    public override string ToString()
    {
        string result = string.Format("{0} {1}", this.FirstName, this.LastName);
        return result;
    }
}