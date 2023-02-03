
using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Models.Equipment
{
    using Models.Equipment.Contracts;

    public abstract class Equipment : IEquipment
    {
        private double weight;
        private decimal price;

        public Equipment(double weight, decimal price)
        {
            Weight = weight;
            Price = price;
        }

        public double Weight
        {
            get => weight;
            private set => weight = value;
        }

        public decimal Price
        {
            get => price;
            private set => price = value;
        }
    }
}
