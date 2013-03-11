using System;
using System.Linq;

class StudentTest
{
    static void Main()
    {
        Student[] students = new Student[3]{
            new Student("Bill", "Gates", 57),
            new Student("Mark", "Zuckerberg", 28),
            new Student("Other", "Name", 18)
        };


        //Task 3
        var getNames = from student in students
                      where student.FirstName.CompareTo(student.LastName) == -1
                      select student;

        foreach (var item in getNames)
        {
            Console.WriteLine("{0} {1}", item.FirstName, item.LastName);
        }

        Console.WriteLine();
        Console.WriteLine(new string('-', 25));
        Console.WriteLine();

        //Task 4
        var findAgeBetween18And24 = from student in students
                      where student.Age >= 18 && student.Age <= 24
                      select student;

        foreach (var item in findAgeBetween18And24)
        {
            Console.WriteLine("{0} {1}", item.FirstName, item.LastName);
        }

        Console.WriteLine();
        Console.WriteLine(new string('-', 25));
        Console.WriteLine();

        //Task 5
        var sortedNamesLinq = students.OrderByDescending(x => x.FirstName).ThenByDescending(x => x.FirstName);
        
        //Task 5 (rewrite)
        var sortedNames = from student in students
                          orderby student.FirstName descending, student.LastName descending
                          select student;

        foreach (var item in sortedNames)
        {
            Console.WriteLine("{0} {1}", item.FirstName, item.LastName);
        }
      
    }
}