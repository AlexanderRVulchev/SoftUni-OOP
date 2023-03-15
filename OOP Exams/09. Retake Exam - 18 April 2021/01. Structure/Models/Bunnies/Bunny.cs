using System;
using System.Collections.Generic;
using System.Text;

namespace Easter.Models.Bunnies
{
    using Contracts;
    using Dyes.Contracts;
    using Utilities.Messages;

    public abstract class Bunny : IBunny
    {
        private string name;
        private int energy;
        private List<IDye> dyes;

        public Bunny(string name, int energy)
        {
            Name = name;
            Energy = energy;
            dyes = new List<IDye>();
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException(ExceptionMessages.InvalidBunnyName);
                name = value;
            }
        }

        public int Energy
        {
            get { return energy; }
            protected set
            {
                if (value < 0)
                    energy = 0;
                else
                    energy = value;
            }
        }

        public ICollection<IDye> Dyes => dyes;

        public void AddDye(IDye dye)
        {
            dyes.Add(dye);
        }

        public abstract void Work();
    }
}
