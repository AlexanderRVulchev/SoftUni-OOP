using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes.Models.Weapons
{
    public class Mace : Weapon
    {
        private const int DAMAGE = 25;

        public Mace(string name, int durability)
            : base(name, durability)
        { }

        public override int DoDamage()
        {
            if (Durability > 0)
                Durability--;
            if (Durability == 0)
                return 0;
            else
                return DAMAGE;
        }
    }
}