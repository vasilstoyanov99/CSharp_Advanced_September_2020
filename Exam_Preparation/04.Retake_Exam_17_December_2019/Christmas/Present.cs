using System;
using System.Collections.Generic;
using System.Text;

namespace Christmas
{
    public class Present
    {
        public string Name { get; set; }
        public double Weight { get; set; }
        public string Gender { get; set; }

        public Present(string name, double weight, string gender)
        {
            Name = name;
            Weight = weight;
            Gender = gender;
        }

        public override string ToString()
        {
            return $"Present {Name} ({Weight}) for a {Gender}"; 
        }
    }
}
