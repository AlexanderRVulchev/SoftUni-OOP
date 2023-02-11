
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Planets
{
    using Contracts;
    using Utilities.Messages;

    public class Planet : IPlanet
    {
        private string name;
        private List<string> items;

        public Planet(string name)
        {
            Name = name;
            items = new List<string>();
        }

        public ICollection<string> Items => items.AsReadOnly();
                
        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException(ExceptionMessages.InvalidPlanetName);
                name = value;
            }
        }
    }
}
