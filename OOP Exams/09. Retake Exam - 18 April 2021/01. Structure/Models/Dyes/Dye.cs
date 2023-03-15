
using System;
using System.Collections.Generic;
using System.Text;

namespace Easter.Models.Dyes
{
    using Contracts;

    public class Dye : IDye
    {
        private int power;

        public Dye(int power)
        {
            this.power = power;
        }

        public int Power
        {
            get { return power; }
            private set
            {
                if (value < 0)
                    power = 0;
                else
                    power = value;
            }
        }

        public bool IsFinished()
        => power == 0;

        public void Use()
        {
            Power -= 10;
        }
    }
}
