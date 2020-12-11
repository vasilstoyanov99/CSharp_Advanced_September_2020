using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CounterStrike.Core.Contracts;
using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Models.Guns.Models;
using CounterStrike.Models.Maps.Contracts;
using CounterStrike.Models.Maps.Models;
using CounterStrike.Models.Players.Contracts;
using CounterStrike.Models.Players.Models;
using CounterStrike.Repositories.Contracts;
using CounterStrike.Repositories.Models;
using CounterStrike.Utilities.Messages;

namespace CounterStrike.Core.Models
{
    public class Controller : IController
    {
        private IRepository<IGun> gunRepository;
        private IRepository<IPlayer> playerRepository;
        private IMap map;

        public Controller()
        {
            gunRepository = new GunRepository();
            playerRepository = new PlayerRepository();
            map = new Map();
        }

        public string AddGun(string type, string name, int bulletsCount)
        {
            IGun gun = null;

            switch (type)
            {
                case "Pistol":
                    gun = new Pistol(name, bulletsCount);
                    break;
                case "Rifle":
                    gun = new Rifle(name, bulletsCount);
                    break;
                default:
                    throw new ArgumentException(ExceptionMessages.InvalidGunType);
            }

            gunRepository.Add(gun);
            return String.Format(OutputMessages.SuccessfullyAddedGun, name);
        }

        public string AddPlayer(string type, string username, int health, int armor, string gunName)
        {
            IGun gun = gunRepository.FindByName(gunName);

            if (gun is null)
            {
                throw new ArgumentException(ExceptionMessages.GunCannotBeFound);
            }

            IPlayer player = null;

            switch (type)
            {
                case "Terrorist":
                    player = new Terrorist(username, health, armor, gun);
                    break;
                case "CounterTerrorist":
                    player = new CounterTerrorist(username, health, armor, gun);
                    break;
                default:
                    throw new ArgumentException(ExceptionMessages.InvalidPlayerType);
            }

            playerRepository.Add(player);
            return String.Format(OutputMessages.SuccessfullyAddedPlayer, username);
        }

        public string StartGame()
        {
            List<IPlayer> allAlivePlayers =
                playerRepository.Models.Where(x => x.IsAlive == true).ToList();
            return map.Start(allAlivePlayers);
        }

        public string Report()
        {
            StringBuilder result = new StringBuilder();

            List<IPlayer> sortedPlayers =
                playerRepository
                    .Models
                    .OrderBy(x => x.GetType().Name)
                    .ThenByDescending(x => x.Health)
                    .ThenBy(x => x.Username).ToList();

            foreach (var player in sortedPlayers)
            {
                result.AppendLine(player.ToString());
            }

            return result.ToString().TrimEnd();
        }
    }
}
