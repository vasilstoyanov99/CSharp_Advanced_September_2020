using System;
using System.Collections.Generic;
using System.Text;

namespace Guild
{
    class Player
    {
        public string Name { get; set; }
        public string Class { get; set; }
        public string Rank { get; set; }
        public string Description { get; set; }

        public Player(string name, string classToInsert )
        {
            Name = name;
            Class = classToInsert;
            Rank = "Trial";
            Description = "n/a";
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"Player {Name}: {Class}");
            result.AppendLine($"Rank: {Rank}");
            result.AppendLine($"Description: {Description}");
            return result.ToString().TrimEnd(); 
        }
    }
}
