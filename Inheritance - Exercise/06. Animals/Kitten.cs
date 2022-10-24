using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Kitten : Cat
    {
        private const string FIXED_GENDER = "Female";

        public override string Gender { get { return FIXED_GENDER; } }

        public Kitten(string name, int age)
            : base(name, age, null)
        { }

        public override string ProduceSound()
            => "Meow";
    }
}
