using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;

namespace Heroes
{
    public class HeroRepository
    {
        public int Count 
        { 
            get 
            {
                return allHeroes.Count;
            }
        }

        private Dictionary<string, Hero> allHeroes;

        public HeroRepository()
        {
            allHeroes = new Dictionary<string, Hero>();
        }

        public void Add(Hero hero)
        {
            allHeroes.Add(hero.Name, hero);
        }

        public void Remove(string name)
        {
            if (allHeroes.ContainsKey(name))
            {
                allHeroes.Remove(name);
            }
        }

        public Hero GetHeroWithHighestStrength()
        {
            return allHeroes.Values.OrderByDescending(x => x.Item.Strength).FirstOrDefault();
        }

        public Hero GetHeroWithHighestAbility()
        {
            return allHeroes.Values.OrderByDescending(x => x.Item.Ability).FirstOrDefault();
        }

        public Hero GetHeroWithHighestIntelligence()
        {
            return allHeroes.Values.OrderByDescending(x => x.Item.Intelligence).FirstOrDefault();
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            foreach (var hero in allHeroes.Values)
            {
                result.Append(hero.ToString());
            }

            return result.ToString().Trim();
        }
    }
}
