using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Aquariums
{
    using AquaShop.Models.Decorations.Contracts;
    using AquaShop.Models.Fish.Contracts;
    using Contracts;
    using System.Linq;
    using Utilities.Messages;

    public abstract class Aquarium : IAquarium
    {
        private string name;
        public int capacity;
        private List<IDecoration> decorations;
        private List<IFish> fish;

        public Aquarium(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(ExceptionMessages.InvalidAquariumName);
                name = value;
            }
        }

        public int Capacity
        {
            get { return capacity; }
            private set { capacity = value; }
        }

        public int Comfort => decorations.Select(x => x.Comfort).Sum();

        public ICollection<IDecoration> Decorations => decorations.AsReadOnly();

        public ICollection<IFish> Fish => fish.AsReadOnly();

        public void AddDecoration(IDecoration decoration)
        {
            decorations.Add(decoration);
        }

        public void AddFish(IFish fish)
        {
            if (this.fish.Count == capacity)
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            this.fish.Add(fish);
        }

        public void Feed()
        {
            this.fish.ForEach(x => x.Eat());
        }

        public string GetInfo()
        {
            StringBuilder sb = new StringBuilder();
            string fishInfo = fish.Any() ? String.Join(", ", fish) : "none";

            sb.AppendLine($"{Name} ({this.GetType().Name}):");
            sb.AppendLine("Fish: " + fishInfo);
            sb.AppendLine($"Decorations: {decorations.Count}");
            sb.Append($"Comfort: {Comfort}");

            return sb.ToString().TrimEnd();
        }

        public bool RemoveFish(IFish fish)
        => this.fish.Remove(fish);
    }
}
