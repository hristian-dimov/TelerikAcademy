using System;

class Frog : Animal
{
    public Frog(string name, int age, AnimalSex sex)
        : base(name, age, sex)
    {
        this.Sound = "I'm a frog. Rubbut Rubbut !";
    }
}