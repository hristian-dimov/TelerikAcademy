using System;
using System.Text;
using System.Collections.Generic;

class Teacher : Person
{
    private readonly List<Discipline> disciplines = new List<Discipline>();

    public Teacher(string name)
        : base(name)
    {
    }

    public void AddDicipline(Discipline discipline)
    {
        this.disciplines.Add(discipline);
    }

    public override string ToString()
    {
        StringBuilder result = new StringBuilder();
        result.Append("Name: " + this.Name + " - Disciplines: ");
        foreach (var discipline in disciplines)
        {
            result.Append(discipline + " ");
        }
        return result.ToString().TrimEnd();
    }
}