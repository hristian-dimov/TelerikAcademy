using System;

class StudentTest
{
    static void Main()
    {
        Student firstStudent = new Student("Mateo", "Needham", " Brinson", 9999999, "Street 5", 500001, University.NBU, Specialty.Math, Faculty.Mathematics);
        Student secondStudent = firstStudent.Clone();
        Student thirdStudent = new Student("Chris", "Norwood", " Varela", 8888888, "Street 125", 600001, University.TU, Specialty.Law, Faculty.Law);

        Console.WriteLine(firstStudent); // ToString
        Console.WriteLine(firstStudent.CompareTo(secondStudent)); // CompareTo
        Console.WriteLine(firstStudent.CompareTo(thirdStudent)); // CompareTo
    }
}