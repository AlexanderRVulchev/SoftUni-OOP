using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Repositories
{
    using Models.Weapons;
    using Models.Weapons.Contracts;
    using Repositories.Contracts;

    public class WeaponRepository : IRepository<IWeapon>
    {
        private List<IWeapon> models;

        public WeaponRepository()
        {
            this.models = new List<IWeapon>();
        }

        public IReadOnlyCollection<IWeapon> Models => throw new NotImplementedException();

        public void AddItem(IWeapon model)
        {
            this.models.Add(model);
        }

        public IWeapon FindByName(string name)
        => models.Find(x => x.GetType().Name == name);

        public bool RemoveItem(string name)
        => models.Remove(models.Find(x => x.GetType().Name == name));
    }
}
