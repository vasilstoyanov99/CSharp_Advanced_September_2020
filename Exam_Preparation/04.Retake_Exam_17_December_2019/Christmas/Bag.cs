using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Christmas
{
   public class Bag
    {
        private Dictionary<string, Present> allPresents;
        public string Color { get; set; }
        public int Capacity { get; set; }

        public int Count 
        {
            get 
            {
                return allPresents.Count;    
            } 
        }
        public Bag(string color, int capacity)
        {
            Color = color;
            Capacity = capacity;
            allPresents = new Dictionary<string, Present>();
        }

        public void Add(Present present)
        {
            if (allPresents.Count <= Capacity)
            {
                allPresents.Add(present.Name, present);
            }
        }

        public bool Remove(string name)
        {
            if (allPresents.ContainsKey(name))
            {
                allPresents.Remove(name);
                return true;
            }
            return false;
        }

        public Present GetHeaviestPresent()
        {
            foreach (var heaviestPresent in allPresents.Values.OrderByDescending(x => x.Weight))
            {
                return heaviestPresent;
            }

            return null;
        }

        public Present GetPresent(string name)
        {
            if (allPresents.ContainsKey(name))
            {
                return allPresents[name];
            }

            return null;
        }

        public string Report()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"{Color} bag contains:");

            foreach (var present in allPresents.Values)
            {
                result.AppendLine(present.ToString());
            }

            return result.ToString().TrimEnd();
        }
    }
}
