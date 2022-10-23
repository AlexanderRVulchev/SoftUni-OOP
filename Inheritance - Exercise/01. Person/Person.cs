using System;
using System.Collections.Generic;
using System.Text;

namespace Person
{
    public class Person
    {
        private string name;
        private int age;

        public string Name { get { return name; } set { name = value; } }

        public virtual int Age
        {
            get { return age; }
            set { if (value >= 0) age = value; }
        }

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public override string ToString()
            => $"Name: {this.Name}, Age: {this.Age}";
    }
}
