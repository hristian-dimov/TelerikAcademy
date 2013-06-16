using System;
using System.IO;
using System.Collections.Generic;
using Wintellect.PowerCollections;

class Program
{
    static void Main()
    {
        SortedDictionary<string, OrderedBag<Student>> courses = new SortedDictionary<string, OrderedBag<Student>>();

        string[] lines = File.ReadAllLines("../../students.txt");

        foreach (var line in lines)
        {
            string[] tokens = line.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

            string firstName = tokens[0].Trim();
            string lastName = tokens[1].Trim();
            string course = tokens[2].Trim();

            if(!courses.ContainsKey(course)) {
                courses.Add(course, new OrderedBag<Student>());
            }

            Student newStudent = new Student(firstName, lastName);
            courses[course].Add(newStudent);
        }

        foreach (var course in courses)
        {
            Console.WriteLine("{0}: {1}", course.Key, string.Join(", ", course.Value));
        }
    }
}