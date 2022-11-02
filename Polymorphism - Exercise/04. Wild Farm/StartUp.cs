using System;
using System.Collections.Generic;

namespace _04._Wild_Farm
{
    public class StartUp
    {
        static void Main()
        {
            List<Animal> animals = new List<Animal>();
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                Animal animal = Factory.GetAnimal(input);
                Console.WriteLine(animal.Sound());
                Food food = Factory.GetFood(Console.ReadLine());
                animal.Eat(food);
                animals.Add(animal);
            }
            foreach (Animal animal in animals)
                Console.WriteLine(animal);
        }
    }
}
