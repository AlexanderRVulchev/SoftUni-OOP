
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Models.Planets
{
    using Models.MilitaryUnits.Contracts;
    using Models.Planets.Contracts;
    using Models.Weapons.Contracts;
    using Repositories;
    using Utilities.Messages;

    public class Planet : IPlanet
    {
        private string name;
        private double budget;
        private UnitRepository army;
        private WeaponRepository weapons;

        public Planet(string name, double budget)
        {
            Name = name;
            Budget = budget;
            army = new UnitRepository();
            weapons = new WeaponRepository();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(ExceptionMessages.InvalidPlanetName);
                name = value;
            }
        }

        public double Budget
        {
            get => budget;
            private set
            {
                if (value < 0)
                    throw new ArgumentException(ExceptionMessages.InvalidBudgetAmount);
                budget = value;
            }
        }

        public double MilitaryPower => CalculateMillitaryPower();

        public IReadOnlyCollection<IMilitaryUnit> Army => army.Models;

        public IReadOnlyCollection<IWeapon> Weapons => weapons.Models;


        public void AddUnit(IMilitaryUnit unit)
        {
            army.AddItem(unit);
        }

        public void AddWeapon(IWeapon weapon)
        {
            weapons.AddItem(weapon);
        }

        public string PlanetInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Planet: {Name}");
            sb.AppendLine($"--Budget: {Budget} billion QUID");
            sb.AppendLine(army.Models.Any()
                ? $"--Forces : {string.Join(", ", army)}"
                : "No units");
            sb.AppendLine(weapons.Models.Any()
                ? $"--Combat equipment: {string.Join(", ", weapons)}"
                : "No weapons");
            sb.Append($"--Military Power: {MilitaryPower}");

            return sb.ToString();
        }

        public void Profit(double amount)
        {
            budget += amount;
        }

        public void Spend(double amount)
        {
            if (budget < amount)
                throw new InvalidOperationException(ExceptionMessages.UnsufficientBudget);
            budget -= amount;
        }

        public void TrainArmy()
        {
            foreach (var unit in Army)
                unit.IncreaseEndurance();
        }

        private double CalculateMillitaryPower()
        {
            double totalAmount = Army.Select(x => x.EnduranceLevel).Sum() +
                                 Weapons.Select(x => x.DestructionLevel).Sum();
            if (Army.Any(x => x.GetType().Name == "AnonymousImpactUnit"))
                totalAmount *= 1.30;
            if (Weapons.Any(x => x.GetType().Name == "NuclearWeapon"))
                totalAmount *= 1.45;
            return Math.Round(totalAmount, 3);
        }
    }
}
