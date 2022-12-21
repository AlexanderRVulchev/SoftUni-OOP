using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes.Repositories
{
    using Models.Contracts;
    using Models.Heroes;
    using Repositories.Contracts;

    public class HeroRepository : IRepository<IHero>
    {
        private List<IHero> heroes;

        public HeroRepository()
        {
            heroes = new List<IHero>();
        }

        public IReadOnlyCollection<IHero> Models => heroes.AsReadOnly();

        public void Add(IHero model)
        {
            heroes.Add(model);
        }

        public IHero FindByName(string name)
        {
            return heroes.Find(h => h.Name == name);
        }

        public bool Remove(IHero model)
        {
            return heroes.Remove(model);
        }
    }
}
