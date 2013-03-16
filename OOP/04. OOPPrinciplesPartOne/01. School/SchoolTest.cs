using System;

class SchoolTest
{
    static void Main()
    {
        Discipline math = new Discipline("Math", 15, 15);
        Discipline biology = new Discipline("Biology", 10, 10);
        Discipline history = new Discipline("History", 5, 5);
        history.Comment = "Optional comment"; // add comment

        Student firstStudent = new Student("Borislav Borislavov", 2);
        firstStudent.Comment = "Optional comment"; // add comment

        Student secondStudent = new Student("Vasil Vasilev", 4);

        Teacher firstTeacher = new Teacher("Ivan Ivanov");
        firstTeacher.AddDicipline(math);

        Teacher secondTeacher = new Teacher("Peter Petrov");
        secondTeacher.AddDicipline(biology);
        secondTeacher.AddDicipline(history);
        secondTeacher.Comment = "Optional comment"; // add comment

        Class firstClass = new Class("12B");
        firstClass.Comment = "Optional comment"; // add comment

        firstClass.AddStudent(firstStudent);
        firstClass.AddStudent(secondStudent);

        firstClass.AddTeacher(firstTeacher);
        firstClass.AddTeacher(secondTeacher);

        Console.WriteLine(firstClass);
    }
}