using System;
using System.Collections.Generic;
using System.Text;

namespace Easter.Repositories
{
    using Contracts;
    using Models.Eggs.Contracts;

    public class EggRepository : IRepository<IEgg>
    {
        private List<IEgg> models;

        public EggRepository()
        {
            models = new List<IEgg>();
        }

        public IReadOnlyCollection<IEgg> Models => models.AsReadOnly();

        public void Add(IEgg model)
        {
            models.Add(model);
        }

        public IEgg FindByName(string name)
        => models.Find(x => x.Name == name);

        public bool Remove(IEgg model)
        => models.Remove(model);
    }
}
