
using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes.Repositories
{
    using Models.Contracts;
    using Models.Weapons;
    using Repositories.Contracts;

    public class WeaponRepository : IRepository<IWeapon>
    {
        private List<IWeapon> weapons;

        public WeaponRepository()
        {
            weapons = new List<IWeapon>();
        }

        public IReadOnlyCollection<IWeapon> Models => weapons.AsReadOnly();

        public void Add(IWeapon model)
        {
            weapons.Add(model);
        }

        public IWeapon FindByName(string name)
        {
            return weapons.Find(w => w.Name == name);
        }

        public bool Remove(IWeapon model)
        {
            return weapons.Remove(model);
        }
    }
}
