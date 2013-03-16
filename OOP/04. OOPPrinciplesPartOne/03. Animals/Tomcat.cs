using System;

class Tomcat : Cat
{
    public Tomcat(string name, int age)
        : base(name, age, AnimalSex.Male)
    {
        this.Sound = "I'm a tomcat. Hhhss Hhsss!";
    }
}