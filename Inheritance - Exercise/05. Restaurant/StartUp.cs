//NOTE: You need a public class StartUp. Create a Restaurant project with the following classes and hierarchy:
//There are Food and Beverages in the restaurant, and they are all products. 
//The Product class must have the following members:
//•	A constructor with the following parameters:
//o Name – string
//o	Price – decimal
//Beverage and Food classes are products. 
//The Beverage class must have the following members:
//•	A constructor with the following parameters: string name, decimal price, double milliliters
//o	Reuse the constructor of the inherited class
//•	Name – string
//•	Price – decimal
//•	Milliliters – double
//HotBeverage and ColdBeverage are beverages and they accept the following parameters upon initialization:
//string name, decimal price, double milliliters. Reuse the constructor of the inherited class.
//Coffee and Tea are hot beverages. The Coffee class must have the following additional members:
//•	double CoffeeMilliliters = 50
//•	decimal CoffeePrice = 3.50
//•	Caffeine – double
//The Food class must have the following members:
//•	A constructor with the following parameters: string name, decimal price, double grams
//o	Name – string
//o	Price – decimal
//o	Grams – double
//MainDish, Dessert, and Starter are food.
//They all accept the following parameters upon initialization:
//string name, decimal price, double grams. Reuse the base class constructor.
//Dessert must accept one more parameter in its constructor: double calories, and has a property:
//•	Calories
//Make Fish, Soup and Cake inherit the proper classes. 
//The Cake class must have the following default values:
//•	Grams = 250
//•	Calories = 1000
//•	CakePrice = 5
//A Fish must have the following default values:
//•	Grams = 22


namespace Restaurant
{
    public class StartUp
    {
        public static void Main()
        {

        }
    }
}