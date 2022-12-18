
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Repositories
{
    using Models.Planets.Contracts;
    using Repositories.Contracts;

    public class PlanetRepository : IRepository<IPlanet>
    {
        private List<IPlanet> models;

        public IReadOnlyCollection<IPlanet> Models => models.AsReadOnly();

        public void AddItem(IPlanet model)
        {
            models.Add(model);
        }

        public IPlanet FindByName(string name)
        => models.Find(x => x.Name == name);

        public bool RemoveItem(string name)
        => models.Remove(models.Find(x => x.Name == name));
    }
}
