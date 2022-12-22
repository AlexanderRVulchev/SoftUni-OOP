
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes.Models.Map
{
    using Models.Contracts;
    using Models.Heroes;

    public class Map : IMap
    {
        public string Fight(ICollection<IHero> players)
        {
            List<IHero> knights = new List<IHero>();
            List<IHero> barbarians = new List<IHero>();
            foreach (IHero hero in players)
            {
                if (hero.GetType() == typeof(Knight))
                    knights.Add(hero);
                else barbarians.Add(hero);
            }
            bool itIsKnightsTurn = true;
            while (knights.Any(k => k.IsAlive) && barbarians.Any(b => b.IsAlive))
            {
                if (itIsKnightsTurn)
                    PlayOutRound(knights, barbarians);
                else
                    PlayOutRound(barbarians, knights);

                itIsKnightsTurn = !itIsKnightsTurn;
            }
            if (knights.Any(k => k.IsAlive))
                return $"The knights took {knights.Where(k => !k.IsAlive).Count()} casualties but won the battle.";
            else
                return $"The barbarians took {barbarians.Where(b => !b.IsAlive).Count()} casualties but won the battle.";
        }

        private void PlayOutRound(List<IHero> attackers, List<IHero> defenders)
        {
            foreach (IHero attacker in attackers.Where(x => x.IsAlive))
                foreach (IHero defender in defenders.Where(x => x.IsAlive))                
                    defender.TakeDamage(attacker.Weapon.DoDamage());
        }
    }
}
