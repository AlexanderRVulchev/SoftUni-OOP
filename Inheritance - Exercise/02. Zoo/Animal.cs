using System;
using System.Collections.Generic;
using System.Text;

namespace Zoo
{
    public class Animal
    {
        protected string name;

        public string Name { get => this.name; set => this.name = value; }

        public Animal(string name)
        {
            this.name = name;
        }
    }
}
