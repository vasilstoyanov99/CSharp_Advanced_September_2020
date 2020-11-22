using System;
using System.Collections.Generic;

using _03.Raiding.Contracts;
using _03.Raiding.Engine.Contracts;
using _03.Raiding.Factories;

namespace _03.Raiding.Engine
{
    public class Engine_Test : IEngine
    {
        private const string VICTORY_MSG = "Victory!";
        public const string DEFEAT_MSG = "Defeat...";

        public void Run()
        {
            HeroFactory heroFactory = new HeroFactory();
            List<BaseHero> raidGroup = new List<BaseHero>();
            int countOfNeededlHeroes = int.Parse(Console.ReadLine());

            while (raidGroup.Count < countOfNeededlHeroes)
            {
                string name = Console.ReadLine();
                string type = Console.ReadLine();

                try
                {
                    BaseHero newHero = heroFactory.CreateHero(name, type);
                    raidGroup.Add(newHero);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }

            long bossPower = long.Parse(Console.ReadLine());
            long raidGroupPower = default;

            if (raidGroup.Count > 0)
            {
                raidGroupPower = GetAllHeroesPowers(raidGroup);
            }

            if (raidGroup.Count > 0)
            {
                if (raidGroupPower >= bossPower)
                {
                    Console.WriteLine(VICTORY_MSG);
                }
                else
                {
                    Console.WriteLine(DEFEAT_MSG);
                }
            }
            else
            {
                Console.WriteLine(DEFEAT_MSG);
            }
        }

        public long GetAllHeroesPowers(List<BaseHero> raidGroup)
        {
            long result = default; 

            foreach (var hero in raidGroup)
            {
                Console.WriteLine(hero.CastAbility());
                result += hero.Power;
            }

            return result;
        }
    }
}
