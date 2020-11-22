using System;

using _03.Raiding.Contracts;
using _03.Raiding.Models;

namespace _03.Raiding.Factories
{
    public class HeroFactory 
    {
        private const string INVALID_HERO_TYPE_MSG = "Invalid hero!";
        public BaseHero CreateHero(string heroName, string heroType)
        {
            BaseHero hero;

            switch (heroType)
            {
                case "Druid":
                    hero = new Druid(heroName);
                    break;
                case "Paladin":
                    hero = new Paladin(heroName);
                    break;
                case "Rogue":
                    hero = new Rogue(heroName);
                    break;
                case "Warrior":
                    hero = new Warrior(heroName);
                    break;
                default:
                    throw new ArgumentException(INVALID_HERO_TYPE_MSG);
            }

            return hero;
        }
    }
}
