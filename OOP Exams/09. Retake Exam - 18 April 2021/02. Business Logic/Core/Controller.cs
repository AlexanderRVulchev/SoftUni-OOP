using System;
using System.Collections.Generic;
using System.Text;

namespace Easter.Core
{
    using Contracts;
    using Easter.Models.Workshops;
    using Easter.Models.Workshops.Contracts;
    using Models.Bunnies;
    using Models.Bunnies.Contracts;
    using Models.Dyes;
    using Models.Dyes.Contracts;
    using Models.Eggs;
    using Models.Eggs.Contracts;
    using Repositories;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using Utilities.Messages;

    public class Controller : IController
    {
        private BunnyRepository bunnies;
        private EggRepository eggs;

        public Controller()
        {
            bunnies = new BunnyRepository();
            eggs = new EggRepository();
        }

        public string AddBunny(string bunnyType, string bunnyName)
        {
            IBunny bunny;
            switch (bunnyType)
            {
                case "HappyBunny": bunny = new HappyBunny(bunnyName); break;
                case "SleepyBunny": bunny = new SleepyBunny(bunnyName); break;
                default: throw new InvalidOperationException(ExceptionMessages.InvalidBunnyType);
            }
            bunnies.Add(bunny);
            return String.Format(OutputMessages.BunnyAdded, bunnyType, bunnyName);
        }

        public string AddDyeToBunny(string bunnyName, int power)
        {
            IBunny bunny = bunnies.FindByName(bunnyName);
            if (bunny == null)
                throw new InvalidOperationException(ExceptionMessages.InexistentBunny);

            IDye dye = new Dye(power);
            bunny.AddDye(dye);
            return String.Format(OutputMessages.DyeAdded, power, bunnyName);
        }

        public string AddEgg(string eggName, int energyRequired)
        {
            IEgg egg = new Egg(eggName, energyRequired);
            eggs.Add(egg);
            return String.Format(OutputMessages.EggAdded, eggName);
        }

        public string ColorEgg(string eggName)
        {
            IEgg egg = eggs.FindByName(eggName);
            var selectedBunnies = bunnies.Models.OrderByDescending(x => x.Energy).TakeWhile(x => x.Energy >= 50);
            if (!selectedBunnies.Any())
                throw new InvalidOperationException(ExceptionMessages.BunniesNotReady);

            IWorkshop workshop = new Workshop();
            foreach (var bunny in selectedBunnies)
            {
                workshop.Color(egg, bunny);
                if (bunny.Energy == 0)
                    bunnies.Remove(bunny);
            }
            if (egg.IsDone())
                return String.Format(OutputMessages.EggIsDone, egg.Name);
            else
                return String.Format(OutputMessages.EggIsNotDone, egg.Name);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{eggs.Models.Where(x => x.IsDone()).Count()} eggs are done!");
            sb.Append($"Bunnies info:");
            foreach (var bunny in bunnies.Models)
            {
                sb.AppendLine();
                sb.AppendLine($"Name: {bunny.Name}");
                sb.AppendLine($"Energy: {bunny.Energy}");
                sb.Append($"Dyes: {bunny.Dyes.Where(x => !x.IsFinished()).Count()} not finished");
            }
            return sb.ToString().TrimEnd();
        }


    }
}
