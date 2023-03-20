using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Repositories
{
    using Models.Decorations.Contracts;
    using Contracts;

    public class DecorationRepository : IRepository<IDecoration>
    {
        private List<IDecoration> models;

        public DecorationRepository()
        {
            models = new List<IDecoration>();
        }

        public IReadOnlyCollection<IDecoration> Models => models.AsReadOnly();

        public void Add(IDecoration model)
        {
            models.Add(model);
        }

        public IDecoration FindByType(string type)
        => models.Find(x => x.GetType().Name == type);

        public bool Remove(IDecoration model)
        => models.Remove(model);
    }
}
