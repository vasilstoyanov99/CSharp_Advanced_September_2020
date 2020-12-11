using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CounterStrike.Models.Maps.Contracts;
using CounterStrike.Models.Players.Contracts;
using CounterStrike.Models.Players.Models;

namespace CounterStrike.Models.Maps.Models
{
    public class Map : IMap
    {
        public string Start(ICollection<IPlayer> players)
        {
            List<IPlayer> terrorists = new List<IPlayer>();
            List<IPlayer> counterTerrorists = new List<IPlayer>();

            foreach (var player in players)
            {
                if (player is Terrorist)
                {
                    terrorists.Add(player);
                }
                else
                {
                    counterTerrorists.Add(player);
                }
            }

            while (CheckIfTeamIsAlive(terrorists) && CheckIfTeamIsAlive(counterTerrorists))
            {
                Shoot(terrorists, counterTerrorists);
                Shoot(counterTerrorists, terrorists);
            }

            if (CheckIfTeamIsAlive(terrorists))
            {
                return "Terrorist wins!";
            }
            else if (CheckIfTeamIsAlive(counterTerrorists))
            {
                return "Counter Terrorist wins!";
            }

            return "Bug";
        }

        private bool CheckIfTeamIsAlive(List<IPlayer> players)
            => players.Any(x => x.IsAlive == true);

        private void Shoot(List<IPlayer> Attacking, List<IPlayer> Attacked)
        {
            foreach (var attacker in Attacking)
            {
                foreach (var attacked in Attacked)
                {
                    attacked.TakeDamage(attacker.Gun.Fire());
                }
            }
        }
    }
}
