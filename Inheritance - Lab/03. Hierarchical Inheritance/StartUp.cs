//3.Hierarchical Inheritance
//NOTE: You need a public StartUp class with the namespace Farm.
//Create three classes named Animal, Dog, and Cat: 
//•	Animal with a single public method Eat() that prints: "eating…"
//•	Dog with a single public method Bark() that prints: "barking…"
//•	Cat with a single public method Meow() that prints: "meowing…"
//•	Dog and Cat should inherit from Animal


using System;

namespace Farm
{
    public class StartUp
    {
        static void Main()
        {
            Dog dog = new Dog();
            dog.Eat();
            dog.Bark();

            Cat cat = new Cat();
            cat.Eat();
            cat.Meow();
        }
    }
}
