using System;
using System.Collections.Generic;
using System.Text;

namespace WarCroft.Entities.Characters
{
    using Contracts;
    using WarCroft.Constants;
    using WarCroft.Entities.Inventory;

    internal class Priest : Character, IHealer
    {
        public Priest(string name)
            : base(name, 50, 25, 40, new Backpack())
        { }

        public void Heal(Character character)
        {
            EnsureAlive();
            character.EnsureAlive();
            character.Health += this.AbilityPoints;
        }
    }
}
