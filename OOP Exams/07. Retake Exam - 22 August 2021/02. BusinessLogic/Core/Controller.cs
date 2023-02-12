using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Core
{
    using Contracts;
    using Models.Astronauts;
    using Models.Astronauts.Contracts;
    using Repositories;
    using Models.Planets;
    using Models.Planets.Contracts;
    using Utilities.Messages;
    using System.Linq;
    using SpaceStation.Models.Mission;

    public class Controller : IController
    {
        private AstronautRepository astronauts;
        private PlanetRepository planets;
        private Mission mission;
        private HashSet<string> exploredPlanets;

        public Controller()
        {
            astronauts = new AstronautRepository();
            planets = new PlanetRepository();
            mission = new Mission();
            exploredPlanets = new HashSet<string>();
        }

        public string AddAstronaut(string type, string astronautName)
        {
            IAstronaut astronaut;
            switch (type)
            {
                case "Biologist": astronaut = new Biologist(astronautName); break;
                case "Geodesist": astronaut = new Geodesist(astronautName); break;
                case "Meteorologist": astronaut = new Meteorologist(astronautName); break;
                default: throw new InvalidOperationException(ExceptionMessages.InvalidAstronautType);
            }
            astronauts.Add(astronaut);
            return String.Format(OutputMessages.AstronautAdded, type, astronautName);
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            IPlanet planet = new Planet(planetName);
            foreach (string item in items)
                planet.Items.Add(item);
            planets.Add(planet);
            return String.Format(OutputMessages.PlanetAdded, planetName);
        }

        public string ExplorePlanet(string planetName)
        {
            IPlanet targetPlanet = planets.FindByName(planetName);
            ICollection<IAstronaut> eligibleAstronauts = astronauts.Models.Where(x => x.Oxygen > 60).ToArray();
            if (!eligibleAstronauts.Any())
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautCount);

            mission.Explore(targetPlanet, eligibleAstronauts);
            exploredPlanets.Add(planetName);
            return String.Format(OutputMessages.PlanetExplored, planetName, eligibleAstronauts.Where(x => !x.CanBreath).Count());
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{exploredPlanets.Count} planets were explored!");
            sb.Append("Astronauts info:");
            foreach (var astronaut in astronauts.Models)
            {
                sb.AppendLine();
                string bagItems = astronaut.Bag.Items.Any() ? string.Join(", ", astronaut.Bag.Items) : "none";
                sb.AppendLine($"Name: {astronaut.Name}");
                sb.AppendLine($"Oxygen: {astronaut.Oxygen}");
                sb.Append($"Bag items: {bagItems}");
            }
            return sb.ToString().TrimEnd();
        }

        public string RetireAstronaut(string astronautName)
        {
            IAstronaut astronaut = astronauts.FindByName(astronautName);
            if (astronaut == null)
                throw new InvalidOperationException(String.Format(ExceptionMessages.InvalidRetiredAstronaut, astronautName));
            astronauts.Remove(astronaut);
            return String.Format(OutputMessages.AstronautRetired, astronautName);
        }
    }
}
