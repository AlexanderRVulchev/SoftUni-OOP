using _07._Military_Elite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _07._Military_Elite
{
    public class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        public string Corps { get; set; }

        public SpecialisedSoldier(string id, string firstName, string lastName, decimal salary, string corps)
            : base(id, firstName, lastName, salary)
        {
            if (corps == "Airforces" || corps == "Marines")
                this.Corps = corps;
            else
                throw new ArgumentException();
        }
    }
}
