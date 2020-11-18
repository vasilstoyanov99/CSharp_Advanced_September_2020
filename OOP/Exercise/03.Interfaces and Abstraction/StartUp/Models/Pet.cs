using StartUp.Contracts;
using System;

namespace StartUp.Models
{
    public class Pet : IBirthable
    {
        public Pet(string name, string birthday)
        {
            Name = name;
            Birthday = birthday;
        }

        public string Name { get; set; }

        public string Birthday { get; private set; }
    }
}
