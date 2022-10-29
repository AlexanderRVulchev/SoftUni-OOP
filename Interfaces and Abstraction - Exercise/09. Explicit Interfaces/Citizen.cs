using System;
using System.Collections.Generic;
using System.Text;

namespace _09._Explicit_Interfaces
{
    public class Citizen : IPerson, IResident
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public int Age { get; set; }

        public Citizen(string name, string country, int age)
        {
            this.Name = name;
            this.Country = country;
            this.Age = age;
        }

        string IPerson.GetName()
        => this.Name;

        string IResident.GetName()
        => $"Mr/Ms/Mrs {this.Name}";        
    }
}
