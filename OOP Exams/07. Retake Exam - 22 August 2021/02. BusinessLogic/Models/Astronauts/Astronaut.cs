using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Astronauts
{
    using Contracts;
    using Bags.Contracts;
    using Utilities.Messages;
    using SpaceStation.Models.Bags;

    public abstract class Astronaut : IAstronaut
    {
        private string name;
        private double oxygen;
        private IBag bag;

        public Astronaut(string name, double oxygen)
        {
            Name = name;
            Oxygen = oxygen;
            bag = new Backpack();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException(ExceptionMessages.InvalidAstronautName);
                name = value;
            }
        }

        public double Oxygen
        {
            get => oxygen;
            protected set
            {
                if (value < 0)
                    throw new ArgumentException(ExceptionMessages.InvalidOxygen);
                oxygen = value;
            }
        }

        public bool CanBreath => oxygen > 0;

        public IBag Bag => bag;

        public virtual void Breath()
        {            
            Oxygen = Math.Max(Oxygen - 10, 0);
        }
    }
}
