using System;
using System.Collections.Generic;
using System.Text;

namespace WarCroft.Entities.Characters
{
    using Contracts;
    using WarCroft.Constants;
    using WarCroft.Entities.Inventory;

    internal class Warrior : Character, IAttacker
    {
        public Warrior(string name)
            : base(name, 100, 50, 40, new Satchel())
        { }

        public void Attack(Character character)
        {
            this.EnsureAlive();
            if (!character.IsAlive)
                return;
            if (character.Equals(this))
                throw new InvalidOperationException(ExceptionMessages.CharacterAttacksSelf);
            character.TakeDamage(this.AbilityPoints);
        }
    }
}
