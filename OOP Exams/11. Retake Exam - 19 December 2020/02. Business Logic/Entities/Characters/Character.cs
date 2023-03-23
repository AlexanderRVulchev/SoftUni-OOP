using System;



namespace WarCroft.Entities.Characters.Contracts
{
    using WarCroft.Constants;
    using WarCroft.Entities.Inventory;
    using WarCroft.Entities.Items;

    public abstract class Character
    {
        private string name;
        private double baseHealth;
        private double health;
        private double baseArmor;
        private double armor;
        private double abilityPoints;
        private Bag bag;

        public Character(string name, double health, double armor, double abilityPoints, Bag bag)
        {
            Name = name;
            BaseHealth = health;
            Health = health;
            BaseArmor = armor;
            Armor = armor;
            AbilityPoints = abilityPoints;
            this.bag = bag;
            IsAlive = true;
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(ExceptionMessages.CharacterNameInvalid);
                name = value;
            }
        }

        public double BaseHealth
        {
            get => baseHealth;
            private set => baseHealth = value;
        }

        public double Health
        {
            get => health;
            set
            {
                if (value > baseHealth)
                    health = baseHealth;
                else if (value < 0)
                    health = 0;
                else
                    health = value;
            }
        }

        public double BaseArmor
        {
            get => baseArmor;
            private set => baseArmor = value;
        }

        public double Armor
        {
            get => armor;
            private set
            {
                if (value < 0)
                    armor = 0;
                else
                    armor = value;
            }
        }

        public double AbilityPoints
        {
            get => abilityPoints;
            private set => abilityPoints = value;
        }

        public Bag Bag
        {
            get => bag;
            private set => bag = value;
        }

        public bool IsAlive { get; set; }

        public void EnsureAlive()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }
        }

        public void TakeDamage(double hitPoints)
        {
            EnsureAlive();
            double armorDamage = Math.Min(Armor, hitPoints);
            double healthDamage = Math.Min(Health, hitPoints - armorDamage);
            Armor -= armorDamage;
            Health -= healthDamage;
        }

        public void UseItem(Item item)
        {
            EnsureAlive();
            item.AffectCharacter(this);
        }
    }
}
