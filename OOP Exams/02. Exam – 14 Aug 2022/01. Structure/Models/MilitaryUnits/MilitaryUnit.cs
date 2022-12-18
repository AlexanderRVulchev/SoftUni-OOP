using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Models.MilitaryUnits
{
    using Models.MilitaryUnits.Contracts;
    using Utilities.Messages;

    public abstract class MilitaryUnit : IMilitaryUnit
    {
        private double cost;
        private int enduraceLevel;

        public MilitaryUnit(double cost)
        {
            this.cost = cost;
            enduraceLevel = 1;
        }

        public double Cost => cost;

        public int EnduranceLevel => enduraceLevel;

        public void IncreaseEndurance()
        {
            if (enduraceLevel == 20)
                throw new ArgumentException(ExceptionMessages.EnduranceLevelExceeded);
            else
                enduraceLevel++;
        }
    }
}
