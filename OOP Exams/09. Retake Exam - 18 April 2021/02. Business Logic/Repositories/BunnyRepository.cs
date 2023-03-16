using System;
using System.Collections.Generic;
using System.Text;

namespace Easter.Repositories
{
    using Contracts;
    using Models.Bunnies.Contracts;

    public class BunnyRepository : IRepository<IBunny>
    {
        private List<IBunny> models;

        public BunnyRepository()
        {
            models = new List<IBunny>();
        }

        public IReadOnlyCollection<IBunny> Models => models.AsReadOnly();

        public void Add(IBunny model)
        {
            models.Add(model);
        }

        public IBunny FindByName(string name)
        => models.Find(x => x.Name == name);

        public bool Remove(IBunny model)
        => models.Remove(model);
    }
}
