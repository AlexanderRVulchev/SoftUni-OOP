//NOTE: You need a public class StartUp.
//Create a hierarchy of Animals. Your program should have three different animals – Dog, Frog, and Cat.
//Deeper in the hierarchy you should have two additional classes – Kitten and Tomcat.
//Kittens are female and Tomcats are male.
//All types of animals should be able to produce some kind of sound - ProduceSound().
//For example, the dog should be able to bark.
//Your task is to model the hierarchy and test its functionality.
//Create an animal of each kind and make them all produce sound.
//You will be given some lines of input. Every two lines will represent an animal.
//On the first line will be the type of animal and on the second – the name, the age, and the gender.
//When the command "Beast!" is given, stop the input and print all the animals in the format shown below.
//Output
//•	Print the information for each animal on three lines. On the first line, print: "{AnimalType}"
//•	On the second line print: "{Name} {Age} {Gender}"
//•	On the third line print the sounds it produces: "{ProduceSound()}"
//Constraints
//•	Each Animal should have a name, an age, and a gender
//•	All input values should not be blank (e.g. name, age, and so on…)
//•	If you receive an input for the gender of a Tomcat or a Kitten, ignore it but create the animal
//•	If the input is invalid for one of the properties, throw an exception with the message: "Invalid input!"
//•	Each animal should have the functionality to ProduceSound()
//•	Here is the type of sound each animal should produce:
//o Dog: "Woof!"
//o Cat: "Meow meow"
//o Frog: "Ribbit"
//o Kittens: "Meow"
//o Tomcat: "MEOW"


using System;
using System.Collections.Generic;

namespace Animals
{
    public class StartUp
    {
        public static void Main()
        {
            string input;            
            List<Animal> animals = new List<Animal>();
            while ((input = Console.ReadLine()) != "Beast!")
            {
                string type = input;
                string[] tokens = Console.ReadLine().Split();
                string name = tokens[0];
                int age = int.Parse(tokens[1]);
                string gender = tokens[2];
                if (age < 0 || (gender != "Male" && gender != "Female"))
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }
                Animal animal = new Animal();
                switch (type)
                {
                    case "Dog": animal = new Dog(name, age, gender); break;
                    case "Cat": animal = new Cat(name, age, gender); break;
                    case "Frog": animal = new Frog(name, age, gender); break;
                    case "Kitten": animal = new Kitten(name, age); break;
                    case "Tomcat": animal = new Tomcat(name, age); break;
                }
                animals.Add(animal);
            }

            foreach (Animal animal in animals)
                Console.WriteLine(animal);
        }
    }
}