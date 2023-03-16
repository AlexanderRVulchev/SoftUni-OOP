
using System;
using System.Collections.Generic;
using System.Text;

namespace Easter.Models.Eggs
{
    using Contracts;
    using Utilities.Messages;

    public class Egg : IEgg
    {
        private string name;
        private int energyRequired;

        public Egg(string name, int energyRequired)
        {
            Name = name;
            EnergyRequired = energyRequired;
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(ExceptionMessages.InvalidEggName);
                name = value;
            }
        }

        public int EnergyRequired
        {
            get { return energyRequired; }
            private set
            {
                if (value < 0)
                    energyRequired = 0;
                else
                    energyRequired = value;
            }
        }

        public void GetColored()
        {
            EnergyRequired -= 10;
        }

        public bool IsDone()
        => energyRequired == 0;
    }
}
