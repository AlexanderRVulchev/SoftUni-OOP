using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Tomcat : Cat
    {
        private const string FIXED_GENDER = "Male";

        public override string Gender { get { return FIXED_GENDER; } }

        public Tomcat(string name, int age)
            : base(name, age, null)
        { }

        public override string ProduceSound()
            => "MEOW";
    }
}
