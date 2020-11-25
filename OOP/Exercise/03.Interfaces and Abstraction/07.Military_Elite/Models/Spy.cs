using _07.Military_Elite.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _07.Military_Elite.Models
{
    public class Spy : Solder, ISpy
    {
        public Spy(int id, string firstName, string lastName, int codeNumber) 
            : base(id, firstName, lastName)
        {
            CodeNumber = codeNumber;
        }

        public int CodeNumber { get; private set; }

        public override string ToString()
        {
            return base.ToString() + Environment.NewLine + $"Code Number: {CodeNumber}";
        }
    }
}
