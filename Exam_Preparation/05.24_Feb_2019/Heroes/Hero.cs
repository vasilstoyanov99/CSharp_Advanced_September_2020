using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes
{
    public class Hero
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public Item Item { get; set; }

        public Hero(string name, int level, Item item)
        {
            Name = name;
            Level = level;
            this.Item = item;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"Hero: {Name} – {Level}lvl");
            result.AppendLine(Item.ToString());

            return result.ToString().Trim();
        }
    }
}
