using System;
using System.Collections.Generic;
using System.Text;


namespace WarCroft.Entities.Items
{
    using Characters.Contracts;

    internal class FirePotion : Item
    {
        public FirePotion()
            : base(5)
        { }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);
            character.Health -= 20;

            if (character.Health <= 0)
                character.IsAlive = false;
        }
    }
}
