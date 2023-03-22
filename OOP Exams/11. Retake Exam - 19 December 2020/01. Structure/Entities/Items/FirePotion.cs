using System;
using System.Collections.Generic;
using System.Text;
using WarCroft.Entities.Characters.Contracts;

namespace WarCroft.Entities.Items
{
    internal class FirePotion : Item
    {
        public FirePotion()
            : base(5)
        { }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);
            character.TakeDamage(20);            
        }
    }
}
