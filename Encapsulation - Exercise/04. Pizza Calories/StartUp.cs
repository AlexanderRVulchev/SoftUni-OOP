//A pizza is made of dough and different toppings.
//You should model a class Pizza, which should have a name, dough, and toppings as fields.
//Every type of ingredient should have its class. Every ingredient has different properties:
//the dough can be white or wholegrain and in addition, it can be crispy, chewy, or homemade.
//The topping can be of type meat, veggies, cheese, or sauce.
//Every ingredient should weigh grams and a method for calculating its calories according to its type.
//Calories per gram are calculated through modifiers.
//Every ingredient has 2 calories per gram as a base and a modifier that gives the exact calories.
//For example, a white dough has a modifier of 1.5, a chewy dough has a modifier of 1.1,
//which means that a white chewy dough,
//weighing 100 grams will have 2 * 100 * 1.5 * 1.1 = 330.00 total calories.
//Your job is to model the classes in such a way that they are properly encapsulated
//and to provide a public method for every pizza that calculates its calories according to the ingredients it has.

using System;


namespace _04._Pizza_Calories
{
    public class StartUp
    {
        static void Main()
        {
            try
            {
                string pizzaName = Console.ReadLine().Split()[1];

                string[] doughInput = Console.ReadLine().Split();
                string flour = doughInput[1];
                string baking = doughInput[2];
                double grams = double.Parse(doughInput[3]);
                Dough dough = new Dough(flour, baking, grams);
                Pizza pizza = new Pizza(pizzaName, dough);

                string input;
                while ((input = Console.ReadLine()) != "END")
                {
                    string topType = input.Split()[1];
                    double topGrams = double.Parse(input.Split()[2]);
                    Topping topping = new Topping(topType, topGrams);
                    pizza.AddTopping(topping);
                }
                Console.WriteLine(pizza);
        }
            catch (Exception ex)
            { Console.WriteLine(ex.Message); }
}
    }
}
