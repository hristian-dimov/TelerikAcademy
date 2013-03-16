using System;

class Person : ICommentable
{
    private string name;

    public Person(string name)
    {
        this.Name = name;
    }

    public string Name
    {
        get { return this.name; }
        private set { this.name = value; }
    }
    public string Comment { get; set; } // ICommentable
}