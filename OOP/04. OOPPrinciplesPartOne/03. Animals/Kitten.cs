using System;

class Kitten : Cat
{
    public Kitten(string name, int age)
        : base(name, age, AnimalSex.Female)
    {
        this.Sound = "I'm a kitten. Mwew Mhew!";
    }
}