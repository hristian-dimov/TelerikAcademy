using System;

abstract class Animal : ISound
{
    private string name;
    private int age;
    private AnimalSex sex;
    private string sound;

    protected Animal(string name, int age, AnimalSex sex)
    {
        this.Name = name;
        this.Age = age;
        this.Sex = sex;
    }

    public string Name
    {
        get { return this.name; }
        set { this.name = value; }
    }

    public int Age
    {
        get { return this.age; }
        set { this.age = value; }
    }

    public AnimalSex Sex
    {
        get { return this.sex; }
        set { this.sex = value; }
    }

    public string Sound
    {
        get { return this.sound; }
        set { this.sound = value; }
    }

    public string MakeSound()
    {
        return this.Name + " says " + this.sound;
    }

    public override string ToString()
    {
        return "My name is " + this.Name + ", I am " + this.Age + " years old ";
    }

}