using System;
using System.Linq;
using System.Collections.Generic;

class Test
{
    static void Main()
    {
        List<Student> students = new List<Student>();
        students.Add(new Student("Erik", "Mccleary", 1));
        students.Add(new Student("Silas", "Holton", 5));
        students.Add(new Student("Freeman", "Landrum", 2));
        students.Add(new Student("Prince", "Hoppe", 6));
        students.Add(new Student("Geraldo", "Hintz", 12));
        students.Add(new Student("Kyle", "Britten", 7));
        students.Add(new Student("Johnny", "Nagler", 8));
        students.Add(new Student("Marcos", "Penick", 10));
        students.Add(new Student("Graig", "Cadogan", 3));
        students.Add(new Student("Virgil", "Giffin", 3));

        var orderByGrade = students.OrderBy(x => x.Grade);

        foreach (Student student in orderByGrade)
        {
            Console.WriteLine(student);
        }

        Console.WriteLine("\n{0}\n", new string('-', 25));

        List<Worker> workers = new List<Worker>();

        workers.Add(new Worker("Mariano", "Bigham", 600, 8));
        workers.Add(new Worker("Max", "Kunkel", 300, 4));
        workers.Add(new Worker("Dexter", "Nail", 1200, 9));
        workers.Add(new Worker("Nathan", "Bouldin", 3000, 12));
        workers.Add(new Worker("Laurence", "Vialpando", 800, 10));
        workers.Add(new Worker("Elmo", "Ord", 500, 8));
        workers.Add(new Worker("Trinidad", "Wilde", 250, 4));
        workers.Add(new Worker("Dante", "Hefner", 600, 6));
        workers.Add(new Worker("Roger", "Hamler", 800, 10));
        workers.Add(new Worker("Isiah", "Cass", 1000, 12));

        var orderByMoneyPerHour = workers.OrderBy(x => x.MoneyPerHour());

        foreach (Worker worker in orderByMoneyPerHour)
        {
            Console.WriteLine(worker);
        }

        Console.WriteLine("\n{0}\n", new string('-', 25));

        List<Human> combinedList = new List<Human>(students.Concat<Human>((workers)));

        var orderByFirstAndLastName = combinedList.OrderBy(x => x.FirstName).ThenBy(x => x.LastName);

        foreach (Human human in orderByFirstAndLastName)
        {
            Console.WriteLine(human);
        }
    }
}