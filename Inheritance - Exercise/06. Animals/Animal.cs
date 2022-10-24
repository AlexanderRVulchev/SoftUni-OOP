using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Animals
{
    public class Animal
    {
        // Fields
        private string name;
        private int age;
        private string gender;

        // Properties
        public string Name { get { return name; } set { name = value; } }
        public int Age { get { return age; } set { age = value; } }
        public virtual string Gender { get { return gender; } set { gender = value; } }

        // Constructors
        public Animal(string name, int age, string gender)
        {
            this.name = name;
            this.age = age;
            this.gender = gender;
        }

        public Animal()
        { }

        // Methods
        public virtual string ProduceSound()
        => null;

        public override string ToString()
        => this.GetType().ToString().Split('.').Last() + Environment.NewLine +
           $"{this.Name} {this.Age} {this.Gender}" + Environment.NewLine +
           ProduceSound();
    }
}
