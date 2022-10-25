//Create two classes: 
//•	Person 
//•	Product
//Each person should have a name, money, and a bag of products.
//Each product should have a name and a cost.
//The name cannot be an empty string. Money cannot be a negative number. 
//Create a program where each command corresponds to a person buying a product.
//If the person can afford a product, add it to his bag.
//If a person doesn’t have enough money,
//print an appropriate message ("{personName} can't afford {productName}").
//On the first two lines, you are given all people and all products.
//After all, purchases print every person in the order of appearance
//and all products that he has bought also in order of appearance.
//If nothing was bought, print the name of the person followed by "Nothing bought". 
//In case of invalid input (negative money Exception message: "Money cannot be negative")
//or an empty name (empty name Exception message: "Name cannot be empty")
//break the program with an appropriate message.


using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Shopping_Spree
{
    public class StartUp
    {
        static void Main()
        {
            List<Person> people = new List<Person>();
            List<Product> products = new List<Product>();
            try
            {
                people = ReadPeopleInfo();
                products = ReadProductsInfo();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string personName = input.Split().First();
                string productName = input.Split().Last();
                Person currentPerson = people.Find(p => p.Name == personName);
                Product currentProduct = products.Find(p => p.Name == productName);
                if (currentPerson != null && currentProduct != null)
                    currentPerson.BuyProduct(currentProduct);
            }
            
            foreach (Person person in people)
            {
                if (person.Bag.Any())
                    Console.WriteLine(person.Name + " - " + String.Join(", ", person.Bag));
                else
                    Console.WriteLine($"{person.Name} - Nothing bought");
            }
        }

        private static List<Person> ReadPeopleInfo()
        {
            List<Person> people = new List<Person>();
            string[] info = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < info.Length; i++)
            {
                string name = info[i]
                    .Split('=', StringSplitOptions.RemoveEmptyEntries).First();
                decimal money = decimal.Parse(info[i]
                    .Split('=', StringSplitOptions.RemoveEmptyEntries).Last());
                people.Add(new Person(name, money));
            }
            return people;
        }

        private static List<Product> ReadProductsInfo()
        {
            List<Product> products = new List<Product>();
            string[] info = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < info.Length; i++)
            {
                string name = info[i]
                    .Split('=', StringSplitOptions.RemoveEmptyEntries).First();
                decimal cost = decimal.Parse(info[i]
                    .Split('=', StringSplitOptions.RemoveEmptyEntries).Last());
                products.Add(new Product(name, cost));
            }
            return products;
        }
    }
}