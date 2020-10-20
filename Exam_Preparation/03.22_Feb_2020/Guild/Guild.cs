using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    class Guild
    {
        private Dictionary<string, Player> allPlayers;
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count 
        { 
            get
            {
                return allPlayers.Count;
            }
        }
        public Guild(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            allPlayers = new Dictionary<string, Player>(Capacity);
        }

        public void AddPlayer(Player player)
        {
            if (allPlayers.Count <= Capacity)
            {
                allPlayers.Add(player.Name, player);
            }
        }

        public bool RemovePlayer(string name)
        {
            if (allPlayers.ContainsKey(name))
            {
                allPlayers.Remove(name);
                return true;
            }

            return false;
        }

        public void PromotePlayer(string name)
        {
            if (allPlayers[name].Rank != "Member")
            {
                allPlayers[name].Rank = "Member";
            }
        }

        public void DemotePlayer(string name)
        {
            if (allPlayers[name].Rank != "Trial")
            {
                allPlayers[name].Rank = "Trial";
            }
        }

        public Player[] KickPlayersByClass(string classToRemove)
        {
            List<Player> removedPlayers = new List<Player>();
            removedPlayers = allPlayers.Values.Where(x => x.Class == classToRemove).ToList();
            allPlayers = allPlayers.Where(x => x.Value.Class != classToRemove).ToDictionary(x => x.Key, y => y.Value);
            return removedPlayers.ToArray();
        } 
        
        public string Report()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"Players in the guild: {Name}");

            foreach (var player in allPlayers.Values)
            {
                result.AppendLine(player.ToString());
            }

            return result.ToString().TrimEnd();
        }
    }
}
