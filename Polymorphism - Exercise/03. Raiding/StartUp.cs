using _03._Raiding.Heroes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Raiding
{
    public class StartUp
    {
        static void Main()
        {
            List<BaseHero> heroes = new List<BaseHero>();
            int numberOfHeroes = int.Parse(Console.ReadLine());
            while (heroes.Count < numberOfHeroes)
            {
                string name = Console.ReadLine();
                string type = Console.ReadLine();
                try
                {
                    BaseHero newHero = HeroFactory.GetHero(name, type);
                    heroes.Add(newHero);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            int bossPower = int.Parse(Console.ReadLine());
            foreach (BaseHero hero in heroes)
                Console.WriteLine(hero.CastAbility());

            int raidPower = heroes.Select(h => h.Power).Sum();
            Console.WriteLine(raidPower >= bossPower ? "Victory!" : "Defeat...");
        }
    }
}
