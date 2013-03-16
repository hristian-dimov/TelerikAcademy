using System;
using System.Linq;
using System.Collections.Generic;

class AnimalTest
{
    static void Main(string[] args)
    {
        Dog dog = new Dog("Rex", 4, AnimalSex.Male);
        Console.WriteLine(dog.MakeSound());

        Kitten kitten = new Kitten("Kitty", 1);
        Console.WriteLine(kitten.MakeSound());

        List<Animal> animals = new List<Animal>() { dog, kitten };

        animals.Add(new Dog("Alice", 3, AnimalSex.Female));
        animals.Add(new Frog("Terminator", 5, AnimalSex.Male));
        animals.Add(new Tomcat("Tom", 2));

        Console.WriteLine("\n{0}\n", new string('-', 25));

        var getAllKindsOfAnimals = animals.GroupBy(x => x.GetType()); // grouping animals by type( classes )

        foreach (var type in getAllKindsOfAnimals)
        {
            Console.WriteLine("{0}s: Average age = {1}", type.Key.Name, type.Average(x => x.Age));
        }
    }
}