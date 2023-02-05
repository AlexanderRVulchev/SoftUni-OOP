
using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Models.Gyms
{
    using Models.Athletes.Contracts;
    using Models.Equipment.Contracts;
    using Models.Gyms.Contracts;
    using System.Dynamic;
    using System.Linq;    
    using Utilities.Messages;

    public abstract class Gym : IGym
    {
        private string name;
        private int capacity;        
        private List<IEquipment> equipment;
        private List<IAthlete> athletes;

        public Gym(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            equipment = new List<IEquipment>();
            athletes = new List<IAthlete>();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException(ExceptionMessages.InvalidGymName);
                name = value;
            }
        }

        public int Capacity
        {
            get => capacity;
            private set => capacity = value;
        }
        
        public double EquipmentWeight => equipment.Sum(x => x.Weight);

        public ICollection<IEquipment> Equipment => equipment.AsReadOnly();

        public ICollection<IAthlete> Athletes => athletes.AsReadOnly();

        public void AddAthlete(IAthlete athlete)
        {            
            if (athletes.Count == capacity)
                throw new InvalidOperationException(ExceptionMessages.NotEnoughSize);
            athletes.Add(athlete);
        }

        public void AddEquipment(IEquipment equipment)
        {            
            this.equipment.Add(equipment);
        }

        public void Exercise()
        {            
            athletes.ForEach(x => x.Exercise());
        }

        public string GymInfo()
        {
            StringBuilder sb = new StringBuilder();
            string athletesInTheGym = athletes.Any() ? string.Join(", ", athletes.Select(x => x.FullName)) : "No athletes";

            sb.AppendLine($"{Name} is a {this.GetType().Name}:");
            sb.Append("Athletes: ");
            sb.AppendLine(athletesInTheGym);
            sb.AppendLine($"Equipment total count: {equipment.Count}");
            sb.Append($"Equipment total weight: {EquipmentWeight:f2} grams");
            return sb.ToString().TrimEnd();
        }

        public bool RemoveAthlete(IAthlete athlete)
        {            
            return athletes.Remove(athlete);
        }
    }
}
