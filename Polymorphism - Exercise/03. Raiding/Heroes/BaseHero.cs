

namespace _03._Raiding.Heroes
{
    public abstract class BaseHero
    {
        public abstract string Name { get; set; }
        public abstract int Power { get; set; }

        public abstract string CastAbility();
    }
}
