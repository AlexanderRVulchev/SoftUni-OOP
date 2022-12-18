using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Models.Weapons
{
    using Models.Weapons.Contracts;
    using Utilities.Messages;

    public abstract class Weapon : IWeapon
    {
        private int destructionLevel;
        private double price;

        public Weapon(int destructionLevel, double price)
        {
            Price = price;
            DestructionLevel = destructionLevel;
        }

        public double Price
        {
            get => price;
            private set => price = value;
        }

        public int DestructionLevel
        {
            get => destructionLevel;
            private set
            {
                if (value < 1)                
                    throw new ArgumentException(ExceptionMessages.TooLowDestructionLevel);                
                if (value > 10)                
                    throw new ArgumentException(ExceptionMessages.TooHighDestructionLevel);
                destructionLevel = value;
            }
        }
    }
}
