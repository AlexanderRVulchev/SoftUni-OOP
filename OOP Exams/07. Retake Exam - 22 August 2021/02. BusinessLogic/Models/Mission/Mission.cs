using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Mission
{
    using Contracts;
    using Models.Astronauts.Contracts;
    using Models.Planets.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class Mission : IMission
    {

        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            foreach (IAstronaut astronaut in astronauts)
            {
                while (astronaut.CanBreath && planet.Items.Any())
                {
                    string item = planet.Items.First();
                    astronaut.Bag.Items.Add(item);
                    planet.Items.Remove(item);
                    astronaut.Breath();
                }
            }
        }
    }
}
