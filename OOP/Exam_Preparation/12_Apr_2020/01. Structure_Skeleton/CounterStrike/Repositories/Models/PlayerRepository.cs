using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CounterStrike.Models.Players.Contracts;
using CounterStrike.Repositories.Contracts;
using CounterStrike.Utilities.Messages;

namespace CounterStrike.Repositories.Models
{
    public class PlayerRepository : IRepository<IPlayer>
    {
        private readonly List<IPlayer> players;

        public PlayerRepository()
        {
            players = new List<IPlayer>();
        }

        public IReadOnlyCollection<IPlayer> Models => players;

        public void Add(IPlayer model)
        {
            if (model is null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidPlayerRepository);
            }

            players.Add(model);
        }

        public bool Remove(IPlayer model)
        {
            if (players.Contains(model))
            {
                players.Remove(model);
                return true;
            }

            return false;
        }

        public IPlayer FindByName(string name)
        {
            return players.FirstOrDefault(x => x.Username == name);
        }
    }
}
