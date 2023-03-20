using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Core
{
    using Models.Aquariums.Contracts;
    using Repositories;
    using Contracts;
    using Models.Aquariums;
    using Utilities.Messages;
    using Models.Decorations;
    using Models.Decorations.Contracts;
    using System.Linq;
    using Models.Fish;
    using Models.Fish.Contracts;


    public class Controller : IController
    {
        private DecorationRepository decorations;
        private List<IAquarium> aquariums;

        public Controller()
        {
            decorations = new DecorationRepository();
            aquariums = new List<IAquarium>();
        }

        public string AddAquarium(string aquariumType, string aquariumName)
        {
            IAquarium aquarium;
            switch (aquariumType)
            {
                case "FreshwaterAquarium": aquarium = new FreshwaterAquarium(aquariumName); break;
                case "SaltwaterAquarium": aquarium = new SaltwaterAquarium(aquariumName); break;
                default: throw new InvalidOperationException(ExceptionMessages.InvalidAquariumType);
            }
            aquariums.Add(aquarium);
            return String.Format(OutputMessages.SuccessfullyAdded, aquariumType);
        }

        public string AddDecoration(string decorationType)
        {
            IDecoration decoration;
            switch (decorationType)
            {
                case "Ornament": decoration = new Ornament(); break;
                case "Plant": decoration = new Plant(); break;
                default: throw new InvalidOperationException(ExceptionMessages.InvalidDecorationType);
            }
            decorations.Add(decoration);
            return String.Format(OutputMessages.SuccessfullyAdded, decorationType);
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            IFish fish;
            IAquarium aquarium = aquariums.Find(x => x.Name == aquariumName);
            switch (fishType)
            {
                case "FreshwaterFish":
                    fish = new FreshwaterFish(fishName, fishSpecies, price);
                    if (aquarium.GetType() != typeof(FreshwaterAquarium))
                        return OutputMessages.UnsuitableWater;
                    break;
                case "SaltwaterFish":
                    fish = new SaltwaterFish(fishName, fishSpecies, price);
                    if (aquarium.GetType() != typeof(SaltwaterAquarium))
                        return OutputMessages.UnsuitableWater;
                    break;
                default: throw new InvalidOperationException(ExceptionMessages.InvalidFishType);
            }
            aquarium.AddFish(fish);
            return String.Format(OutputMessages.EntityAddedToAquarium, fishType, aquariumName);
        }

        public string CalculateValue(string aquariumName)
        {
            IAquarium aquarium = aquariums.Find(x => x.Name == aquariumName);

            decimal fishValue = aquarium.Fish.Select(x => x.Price).Sum();
            decimal decorationsValue = aquarium.Decorations.Select(x => x.Price).Sum();
            decimal totalAquariumValue = fishValue + decorationsValue;

            return String.Format(OutputMessages.AquariumValue, aquariumName, totalAquariumValue);
        }

        public string FeedFish(string aquariumName)
        {
            IAquarium aquarium = aquariums.Find(x => x.Name == aquariumName);
            aquarium.Feed();
            return String.Format(OutputMessages.FishFed, aquarium.Fish.Count);
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            IDecoration decoration = decorations.FindByType(decorationType);
            IAquarium aquarium = aquariums.FirstOrDefault(x => x.Name == aquariumName);
            if (decoration == null)
                throw new InvalidOperationException(String.Format(ExceptionMessages.InexistentDecoration, decorationType));

            decorations.Remove(decoration);
            aquarium.AddDecoration(decoration);

            return String.Format(OutputMessages.EntityAddedToAquarium, decorationType, aquariumName);
        }

        public string Report()
        => String.Join(Environment.NewLine, aquariums.Select(x => x.GetInfo()));
    }
}
