using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class MainClass
{
    enum Sex { Male, Female };

    public class Human
    {
        public Sex Sex { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }

    public void Create(int age)
    {
        Human newHuman = new Human();
        newHuman.Age = age;

        if (age % 2 == 0)
        {
            newHuman.Name = "Батката";
            newHuman.Sex = Sex.Male;
        }
        else
        {
            newHuman.Name = "Мацето";
            newHuman.Sex = Sex.Female;
        }
    }

    public static void Main()
    {
    }
}