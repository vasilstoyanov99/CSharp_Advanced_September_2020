using StartUp.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace StartUp.Models
{
    public class Rebel : IBuyer
    {
        public Rebel(string group, string name)
        {
            Food = 0;
            Group = group;
            Name = name;
        }
        public int Food { get; private set; }

        public string Group { get; private set; }

        public string Name { get; private set; }

        public void BuyFood()
        {
            Food += 5;
        }
    }
}
