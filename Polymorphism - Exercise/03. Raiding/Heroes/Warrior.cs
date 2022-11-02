

namespace _03._Raiding.Heroes
{
    public class Warrior : BaseHero
    {
        public override string Name { get; set; }
        public override int Power { get; set; }

        public Warrior(string name)
        {
            Name = name;
            Power = 100;
        }

        public override string CastAbility()
        => $"{GetType().Name} - {Name} hit for {Power} damage";
    }
}
