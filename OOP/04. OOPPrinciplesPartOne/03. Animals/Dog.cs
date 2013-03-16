using System;

class Dog : Animal
{
    public Dog(string name, int age, AnimalSex sex)
        : base(name, age, sex)
    {
        this.Sound = "I'm a dog. Wuff Wuff !";
    }
}