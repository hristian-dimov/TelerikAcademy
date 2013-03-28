using System;

class Person
{
    public string Name { get; private set; }
    public int? Age { get; private set; }

    public Person(string name, int? age = null)
    {
        this.Name = name;
        this.Age = age;
    }

    public override string ToString()
    {
        return string.Format("Name: {0}; Age: {1}",
            this.Name, this.Age == null ? "<unspecified>" : this.Age.ToString());
    }
}