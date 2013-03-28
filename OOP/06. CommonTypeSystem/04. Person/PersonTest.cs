using System;

class PersonTest
{
    static void Main()
    {
        Person firstPerson = new Person("Tomcat", 5);
        Person secondPerson = new Person("Donatello");

        Console.WriteLine(firstPerson);
        Console.WriteLine(secondPerson);
    }
}