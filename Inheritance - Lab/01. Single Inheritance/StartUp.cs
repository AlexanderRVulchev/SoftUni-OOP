//1.Single Inheritance
//NOTE: You need a public StartUp class with the namespace Farm.
//Create two classes named Animal and Dog:
//•	Animal with a single public method Eat() that prints: "eating…"
//•	Dog with a single public method Bark() that prints: "barking…"
//•	Dog should inherit from Animal


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
        }
    }
}
