using System;
using System.Collections.Generic;
using System.Text;


namespace WarCroft.Entities.Items
{
    using Characters.Contracts;

    public class HealthPotion : Item
    {
        public HealthPotion()
            : base(5)
        { }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);
            character.Health += 20;            
        }
    }
}
