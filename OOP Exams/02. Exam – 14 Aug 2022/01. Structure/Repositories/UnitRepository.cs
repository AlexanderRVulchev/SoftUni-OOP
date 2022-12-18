using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Repositories
{
    using Models.MilitaryUnits.Contracts;    
    using Repositories.Contracts;

    public class UnitRepository : IRepository<IMilitaryUnit>
    {
        private List<IMilitaryUnit> models;

        public UnitRepository()
        {
            models = new List<IMilitaryUnit>();
        }

        public IReadOnlyCollection<IMilitaryUnit> Models => models.AsReadOnly();

        public void AddItem(IMilitaryUnit model)
        {
            models.Add(model);
        }

        public IMilitaryUnit FindByName(string name)
        => models.Find(x => x.GetType().Name == name);

        public bool RemoveItem(string name)
        => models.Remove(models.Find(x => x.GetType().Name == name));
    }
}
