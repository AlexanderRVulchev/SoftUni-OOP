using System;
using System.Collections.Generic;

namespace _09._Explicit_Interfaces
{
    public class StartUp
    {
        static void Main()
        {
            string input;
            while((input = Console.ReadLine()) != "End")
            {
                string name = input.Split()[0];
                string country = input.Split()[1];
                int age = int.Parse(input.Split()[2]);
                Citizen citizen = new Citizen(name, country, age);
                Console.WriteLine((citizen as IPerson).GetName());
                Console.WriteLine((citizen as IResident).GetName());                                          
            }
        }
    }
}
