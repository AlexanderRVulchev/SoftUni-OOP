using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Repositories
{
    using Contracts;
    using Models.Planets.Contracts;

    public class PlanetRepository : IRepository<IPlanet>
    {
        private List<IPlanet> models;

        public PlanetRepository()
        {
            models = new List<IPlanet>();
        }

        public IReadOnlyCollection<IPlanet> Models => models.AsReadOnly();

        public void Add(IPlanet model)
        {
            models.Add(model);
        }

        public IPlanet FindByName(string name)
        => models.Find(x => x.Name == name);

        public bool Remove(IPlanet model)
        => models.Remove(model);
    }
}
